package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import Common.Base;
import LBXZ.FB_FC;
import com.example.administrator.Public.R;

public class FB_FC_XZL_LB extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_xzl_lb);
        initView();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_xzlcs).setOnClickListener(this);
        findViewById(R.id.ll_xzlcz).setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC");
                break;
            case R.id.ll_xzlcs:
                YMTZ("FB_FC_XZL_CS");
                break;
            case R.id.ll_xzlcz:
                YMTZ("FB_FC_XZL_CZ");
                break;

        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC") {
            Intent intent = new Intent(FB_FC_XZL_LB.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_XZL_CS") {
            Intent intent = new Intent(FB_FC_XZL_LB.this, FB_FC_XZL_CS.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_XZL_CZ") {
            Intent intent = new Intent(FB_FC_XZL_LB.this, FB_FC_XZL_CZ.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
