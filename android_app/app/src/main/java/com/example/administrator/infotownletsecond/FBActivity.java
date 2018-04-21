package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;

public class FBActivity extends AppCompatActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb);
        ViewGroup vgxx = (ViewGroup) findViewById(R.id.llXX);
        ViewGroup vggrzx = (ViewGroup) findViewById(R.id.llGRZX);
        ViewGroup vgsy = (ViewGroup) findViewById(R.id.llSY);
        vgxx.setOnClickListener(this);
        vggrzx.setOnClickListener(this);
        vgsy.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llSY:
                YMTZ("SY");
                break;
            case R.id.llFB:
                YMTZ("FB");
                break;
            case R.id.llXX:
                YMTZ("XX");
                break;
            case R.id.llGRZX:
                YMTZ("GRZX");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if(id == "SY") {
            Intent intent = new Intent(FBActivity.this, MainActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "GRZX") {
            Intent intent = new Intent(FBActivity.this, GRZXActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "XX") {
            Intent intent = new Intent(FBActivity.this, XXActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
