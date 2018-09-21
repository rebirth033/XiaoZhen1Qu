package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

public class FBActivity extends BaseActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_main);
        resetBottomMenu();
        ImageView ivsy_fb = (ImageView) findViewById(R.id.ivFB);
        ivsy_fb.setImageResource(R.drawable.dbcd_fb_active);
        findById();
    }

    private void findById() {
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
            Intent intent = new Intent(FBActivity.this, SY_MainActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "GRZX") {
            Intent intent = new Intent(FBActivity.this, GRZX_MainActivity.class);
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
