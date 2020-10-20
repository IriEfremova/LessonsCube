package com.example.pixeldraw;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;

import androidx.annotation.Nullable;


public class PixelCanvas extends View {
    public PixelCanvas(Context context) {
        super(context);
    }

    public PixelCanvas(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
    }

    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);

        int size = 50;
        int countX = canvas.getWidth() / size;
        int countY = canvas.getHeight() / size;

        Paint paint = new Paint();

        for(int i = 0; i <= countX; i++){
            canvas.drawLine(i * size, 0, i * size,canvas.getHeight(), paint);
        }

        for(int i = 0; i <= countY; i++){
            canvas.drawLine(0, i * size, canvas.getWidth(), i * size, paint);
        }

    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        return super.onTouchEvent(event);


        event.getX()

    }
}
