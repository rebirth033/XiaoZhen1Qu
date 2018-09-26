package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import java.net.URL;

public class GRZX_MainActivity extends BaseActivity implements OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.grzx_main);
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
        LinearLayout ll_grzx_wdfb = (LinearLayout) findViewById(R.id.llWDFB);
        vgfb.setOnClickListener(this);
        vgxx.setOnClickListener(this);
        vgsy.setOnClickListener(this);
        iv_grzx_djtxdl.setOnClickListener(this);
        ll_grzx_wdfb.setOnClickListener(this);

        try {
            URL picUrl = new URL("http://www.915fl.com/Areas/Business/Photos/5d14677c5a024ac1bd4c6b7eaa3cce99/GRZL/TX.jpg?j=" + Math.random());
            Bitmap pngBM = BitmapFactory.decodeStream(picUrl.openStream());
            iv_grzx_djtxdl.setImageBitmap(pngBM);
        }
        catch (Exception e){
            e.printStackTrace();
        }
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
            case R.id.llWDFB:
                if(YHM != null)
                    YMTZ("WDFB");
                else
                    YMTZ("YHDL");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if(id == "SY") {
            Intent intent = new Intent(GRZX_MainActivity.this, SY_MainActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "FB") {
            Intent intent = new Intent(GRZX_MainActivity.this, FBActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "XX") {
            Intent intent = new Intent(GRZX_MainActivity.this, XXActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "YHDL") {
            Intent intent = new Intent(GRZX_MainActivity.this, YHDLActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "WDFB") {
            Intent intent = new Intent(GRZX_MainActivity.this, GRZX_WDFBActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
