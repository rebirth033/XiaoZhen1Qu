package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ImageView;

public class GRZXActivity extends BaseActivity implements OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.grzx);
        resetBottomMenu();

        ImageView ivsy_grzx = (ImageView) findViewById(R.id.ivGRZX);
        ivsy_grzx.setImageResource(R.drawable.dbcd_grzx_active);
        findById();
    }

    private void findById() {
        ViewGroup vgfb = (ViewGroup) findViewById(R.id.llFB);
        ViewGroup vgxx = (ViewGroup) findViewById(R.id.llXX);
        ViewGroup vgsy = (ViewGroup) findViewById(R.id.llSY);
        ImageView iv_grzx_djtxdl = (ImageView) findViewById(R.id.ivDJTXDL);
        vgfb.setOnClickListener(this);
        vgxx.setOnClickListener(this);
        vgsy.setOnClickListener(this);
        iv_grzx_djtxdl.setOnClickListener(this);
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
            case R.id.ivDJTXDL:
                YMTZ("YHDL");
                break;
        }
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
        if(id == "YHDL") {
            Intent intent = new Intent(GRZXActivity.this, YHDLActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
