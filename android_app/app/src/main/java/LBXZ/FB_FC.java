package LBXZ;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import Common.Base;
import FBXX.FC.FB_FC_ZZ;

import com.example.administrator.Public.R;

public class FB_FC extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc);
        findById();
    }

    private void findById() {
        ImageView ivBack = (ImageView) findViewById(R.id.ivBACK);
        ViewGroup zzxx = (ViewGroup) findViewById(R.id.llZZ);
        ivBack.setOnClickListener(this);
        zzxx.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("FB_Main");
                break;
            case R.id.llZZ:
                YMTZ("FB_FC_ZZ_Model");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "FB_Main") {
            Intent intent = new Intent(FB_FC.this, FB_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_ZZ_Model") {
            Intent intent = new Intent(FB_FC.this, FB_FC_ZZ.class);
            intent.putExtra("YMMC", "FB_FC");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
