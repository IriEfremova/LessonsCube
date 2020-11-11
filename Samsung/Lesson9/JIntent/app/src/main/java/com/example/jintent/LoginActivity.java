package com.example.jintent;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class LoginActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        String str = getIntent().getStringExtra("Login");

        EditText login = findViewById(R.id.editText);
        login.setText(str);
    }

    public void onClick(View view){
        if(view.getId() == R.id.button2) {
            Intent i = new Intent();
            i.putExtra("ReturnData", "Login & Password");
            setResult(RESULT_OK, i);
            finish();
        }
        if(view.getId() == R.id.button3) {
            Intent i = new Intent();
            i.putExtra("ReturnData", "Cancel login");
            setResult(RESULT_CANCELED, i);
            finish();
        }

    }
}
