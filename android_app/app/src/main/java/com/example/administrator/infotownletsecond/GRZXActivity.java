package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;

public class GRZXActivity extends AppCompatActivity implements OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.grzx);
    }

    //事件监听
    public void onClick(View view) {

    }

    //个人中心
    public void YMTZ(String id) {
        if(id == "SY") {
            Intent intent = new Intent(GRZXActivity.this, MainActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "FB") {
            Intent intent = new Intent(GRZXActivity.this, FBActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "XX") {
            Intent intent = new Intent(GRZXActivity.this, XXActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
