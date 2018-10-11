package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import com.example.administrator.Public.R;
import COMMON.Base;
import LBXZ.FB_FC;

public class FB_FC_ZZ extends Base implements View.OnClickListener {

    private TextView mtvxqmc;
    private TextView mtvmj;
    //自定义的弹出框类
    FB_FC_MJ menuWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_zz);
        Intent intent = getIntent();
        findById();
        String XQMC = intent.getStringExtra("XQMC");
        String YMMC = intent.getStringExtra("YMMC");
        if(YMMC.equalsIgnoreCase("FB_FC_XQCX"))
            mtvxqmc.setText(XQMC);
    }

    private void findById() {
        ImageView ivBack = (ImageView) findViewById(R.id.ivBACK);
        ViewGroup mllxq = (ViewGroup) findViewById(R.id.ll_xq);
        ViewGroup mllmj = (ViewGroup) findViewById(R.id.ll_mj);
        mtvxqmc = (TextView) findViewById(R.id.tv_xqmc);
        mtvmj = (TextView) findViewById(R.id.tv_mj);
        ivBack.setOnClickListener(this);
        mllxq.setOnClickListener(this);
        mllmj.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("FB_FC");
                break;
            case R.id.ll_xq:
                YMTZ("FB_FC_XQCX");
                break;
            case R.id.ll_mj:
                YMTZ("FB_FC_MJ");
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
        if (id == "FB_FC_MJ") {
            menuWindow = new FB_FC_MJ(FB_FC_ZZ.this,null);
            //显示窗口
            menuWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM|Gravity.CENTER_HORIZONTAL, 0, 0); //设置layout在PopupWindow中显示的位置

        }
    }
}
