package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

public class FB_Main extends Base implements View.OnClickListener {

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
        TextView vgwdfb = (TextView) findViewById(R.id.tvWDFB);
        ViewGroup vgfc = (ViewGroup) findViewById(R.id.llFC);
        ViewGroup vgeswp = (ViewGroup) findViewById(R.id.llESWP);
        ViewGroup vgcl = (ViewGroup) findViewById(R.id.llCL);
        ViewGroup vgcw = (ViewGroup) findViewById(R.id.llCW);
        ViewGroup vgswfw = (ViewGroup) findViewById(R.id.llSWFW);
        vgxx.setOnClickListener(this);
        vggrzx.setOnClickListener(this);
        vgsy.setOnClickListener(this);
        vgwdfb.setOnClickListener(this);
        vgfc.setOnClickListener(this);
        vgeswp.setOnClickListener(this);
        vgcl.setOnClickListener(this);
        vgcw.setOnClickListener(this);
        vgswfw.setOnClickListener(this);
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
            case R.id.tvWDFB:
                if (YHM != "")
                    YMTZ("WDFB");
                else
                    YMTZ("YHDL");
                break;
            case R.id.llFC:
                YMTZ("FC");
                break;
            case R.id.llESWP:
                YMTZ("ESWP");
                break;
            case R.id.llCL:
                YMTZ("CL");
                break;
            case R.id.llCW:
                YMTZ("CW");
                break;
            case R.id.llSWFW:
                YMTZ("SWFW");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if(id == "SY") {
            Intent intent = new Intent(FB_Main.this, SY_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "GRZX") {
            Intent intent = new Intent(FB_Main.this, GRZX_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "XX") {
            Intent intent = new Intent(FB_Main.this, XX_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "YHDL") {
            Intent intent = new Intent(FB_Main.this, YHDL.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "WDFB") {
            Intent intent = new Intent(FB_Main.this, GRZX_WDFB.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FC") {
            Intent intent = new Intent(FB_Main.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "ESWP") {
            Intent intent = new Intent(FB_Main.this, FB_ESWP.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "CL") {
            Intent intent = new Intent(FB_Main.this, FB_CL.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "CW") {
            Intent intent = new Intent(FB_Main.this, FB_CW.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "SWFW") {
            Intent intent = new Intent(FB_Main.this, FB_SWFW.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
