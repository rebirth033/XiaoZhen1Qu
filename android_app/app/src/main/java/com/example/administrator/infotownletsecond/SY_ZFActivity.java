package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

public class SY_ZFActivity extends AppCompatActivity implements View.OnClickListener {

    private ImageView mivBACK;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sy_zf);
        findById();
    }

    private void findById() {
        mivBACK = (ImageView) findViewById(R.id.ivBACK);
        mivBACK.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("BACK");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if(id == "BACK") {
            Intent intent = new Intent(SY_ZFActivity.this, MainActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
