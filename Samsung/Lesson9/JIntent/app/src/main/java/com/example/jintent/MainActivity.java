package com.example.jintent;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    int REQEST_LOGIN = 101;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onClick(View view){

        Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://google.com"));
        if (intent.resolveActivity(getPackageManager())!=null)
            startActivity(intent);
        else
            Toast.makeText(getApplicationContext(), "Intent (ACTION_VIEW) не обработан!", Toast.LENGTH_LONG).show();

    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == REQEST_LOGIN) {
            TextView tv = findViewById(R.id.textView);
            switch (resultCode) {
                case RESULT_OK:
                    tv.setText(data.getStringExtra("ReturnData"));
                    break;
                case RESULT_CANCELED:
                    tv.setText(data.getStringExtra("ReturnData"));
                    break;
            }    }

    }
}
