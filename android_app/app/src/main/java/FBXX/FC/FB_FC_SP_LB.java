package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import Common.Base;
import LBXZ.FB_FC;
import com.example.administrator.Public.R;

public class FB_FC_SP_LB extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_sp_lb);
        initView();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_spcs).setOnClickListener(this);
        findViewById(R.id.ll_spcz).setOnClickListener(this);
        findViewById(R.id.ll_syzr).setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC");
                break;
            case R.id.ll_spcs:
                YMTZ("FB_FC_SP_CS");
                break;
            case R.id.ll_spcz:
                YMTZ("FB_FC_SP_CZ");
                break;
            case R.id.ll_syzr:
                YMTZ("FB_FC_SP_ZR");
                break;

        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC") {
            Intent intent = new Intent(FB_FC_SP_LB.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_SP_CS") {
            Intent intent = new Intent(FB_FC_SP_LB.this, FB_FC_SP_CS.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_SP_CZ") {
            Intent intent = new Intent(FB_FC_SP_LB.this, FB_FC_SP_CZ.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_SP_ZR") {
            Intent intent = new Intent(FB_FC_SP_LB.this, FB_FC_SP_ZR.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
