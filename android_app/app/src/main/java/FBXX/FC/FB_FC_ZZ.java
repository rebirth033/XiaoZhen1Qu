package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import com.example.administrator.Public.R;
import COMMON.Base;
import LBXZ.FB_FC;

public class FB_FC_ZZ extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_zz);
        findById();
    }

    private void findById() {
        ImageView ivBack = (ImageView) findViewById(R.id.ivBACK);
        ViewGroup mllxq = (ViewGroup) findViewById(R.id.llXQ);
        ivBack.setOnClickListener(this);
        mllxq.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("FB_FC");
                break;
            case R.id.llXQ:
                YMTZ("FB_FC_XQCX");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "FB_FC") {
            Intent intent = new Intent(FB_FC_ZZ.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_XQCX") {
            Intent intent = new Intent(FB_FC_ZZ.this, FB_FC_XQCX.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
