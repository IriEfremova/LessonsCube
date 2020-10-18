package com.example.sunsystem;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.Log;
import android.view.View;

public class MyCanvas extends View {
    int N = 2; //количество планет + солнце
    String[] name = new String[N]; //названия планет и солнца
    float[] radius = new float[N]; //радиусы планет и солнца
    int[] color = new int[N];
    float[] dist = new float[N]; //координата х для отрисовки планеты
    float[] x = new float[N]; //координата х для отрисовки планеты
    float[] y = new float[N]; //координата y для отрисовки планеты
    double step = 0;
    public MyCanvas(Context context) {
        super(context);

        initPlanet();
    }

    private void initPlanet(){
        name[0] = "Солнце";
        name[0] = "Меркурий";

        radius[0] = 7000;
        radius[1] = 2440;

        color[0] = Color.YELLOW;
        color[1] = Color.BLACK ;

        dist[1] = 15000;

        updatePlanet();
    }

    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);
        drawPlanet(canvas);
        updatePlanet();
        invalidate();
    }

    private void updatePlanet(){
        for(int i = 1; i < N; i++) {
            x[i] = (float) (dist[i] * Math.cos(step));
            y[i] = (float) (dist[i] * Math.sin(step));
        }
        step += Math.PI / 180;
    }

    private  void drawPlanet(Canvas canvas){
        Paint paint = new Paint();
        for(int i = 0; i < N; i++) {
            paint.setColor(color[i]);
            canvas.drawCircle(canvas.getWidth() / 2 + x[i] * 0.01F, canvas.getHeight() / 2 + y[i] * 0.01F, radius[i] * 0.01F, paint);
        }

    }
}
