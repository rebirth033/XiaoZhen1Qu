package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

public class SY_SWFWActivity extends BaseActivity implements View.OnClickListener {

    private ImageView mivBACK;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sy_swfw);
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

    //首页_租房
    public void YMTZ(String id) {
        if(id == "BACK") {
            Intent intent = new Intent(SY_SWFWActivity.this,SY_MainActivity.class);
            finish();//关闭当前页面
        }
    }
}
