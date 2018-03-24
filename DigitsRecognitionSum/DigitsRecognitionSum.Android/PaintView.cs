using System;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Util;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace DigitsRecognitionSum.Droid
{
    public class PaintView : View
    {
        Dictionary<int, Paint> paints = new Dictionary<int, Paint>();
        Dictionary<int, MotionEvent.PointerCoords> coords = new Dictionary<int, MotionEvent.PointerCoords>();
        Canvas drawCanvas;
        Paint drawPaint;
        Bitmap canvasBitmap;        

        public PaintView(Context context) : base(context, null, 0) { }
        public PaintView(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public PaintView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            canvasBitmap = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
            drawCanvas = new Canvas(canvasBitmap);

            drawCanvas.DrawColor(Color.White, PorterDuff.Mode.Add);

            drawPaint = new Paint() { Color = Color.Black, StrokeWidth = 20f, AntiAlias = true };
            drawPaint.SetStyle(Paint.Style.Stroke);
        }

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawBitmap(canvasBitmap, 0, 0, null);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            base.OnTouchEvent(e);
            switch (e.ActionMasked)
            {
                case MotionEventActions.Down:
                    {
                        int id = e.GetPointerId(0);
                        paints.Add(id, drawPaint);
                        var start = new MotionEvent.PointerCoords();
                        e.GetPointerCoords(id, start);
                        coords.Add(id, start);
                        return true;
                    }
                case MotionEventActions.Move:
                    {
                        for (int index = 0; index < e.PointerCount; index++)
                        {
                            var id = e.GetPointerId(index);
                            float x = e.GetX(index);
                            float y = e.GetY(index);
                            drawCanvas.DrawLine(coords[id].X, coords[id].Y, x, y, paints[id]);
                            coords[id].X = x;
                            coords[id].Y = y;
                        }
                        Invalidate();
                        return true;
                    }
                case MotionEventActions.Up:
                    {
                        int id = e.GetPointerId(0);
                        paints.Remove(id);
                        coords.Remove(id);
                        return true;
                    }
                default:
                    return false;
            }
        }        

        public void Clear()
        {
            drawCanvas.DrawColor(Color.White, PorterDuff.Mode.Add);
            Invalidate();
        }

        public void Save(string tag)
        {            
            try
            {                
                using (var os = new FileStream(Android.OS.Environment.ExternalStorageDirectory + "/DCIM/drs_" + tag + ".jpg", FileMode.Create))
                {
                    canvasBitmap.Compress(Bitmap.CompressFormat.Jpeg, 95, os);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}