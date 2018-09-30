package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;

public class SY_ZP extends Base implements View.OnClickListener {

    private ImageView mivBACK;
    private LinearLayout mllRMTJ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sy_zp);
        findById();
    }

    private void findById() {
        mivBACK = (ImageView) findViewById(R.id.ivBACK);
        mivBACK.setOnClickListener(this);
        mllRMTJ = (LinearLayout) findViewById(R.id.llRMTJ);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("BACK");
                break;
        }
    }

    //首页_招聘
    public void YMTZ(String id) {
        if(id == "BACK") {
            Intent intent = new Intent(SY_ZP.this,SY_Main.class);
            finish();//关闭当前页面
        }
    }
}
