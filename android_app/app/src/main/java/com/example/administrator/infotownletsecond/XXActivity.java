package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

public class XXActivity extends BaseActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.xx);
        resetBottomMenu();
        ImageView ivsy_xx = (ImageView) findViewById(R.id.ivXX);
        ivsy_xx.setImageResource(R.drawable.dbcd_xx_active);
        findById();
    }

    private void findById() {
        ViewGroup vgfb = (ViewGroup) findViewById(R.id.llFB);
        ViewGroup vggrzx = (ViewGroup) findViewById(R.id.llGRZX);
        ViewGroup vgsy = (ViewGroup) findViewById(R.id.llSY);
        vgfb.setOnClickListener(this);
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
            Intent intent = new Intent(XXActivity.this, MainActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "FB") {
            Intent intent = new Intent(XXActivity.this, FBActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "GRZX") {
            Intent intent = new Intent(XXActivity.this, GRZXActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
