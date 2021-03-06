package LBXZ;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import Common.Base;
import FBXX.FC.FB_FC_ESF;
import FBXX.FC.FB_FC_HZ;
import FBXX.FC.FB_FC_QT_LB;
import FBXX.FC.FB_FC_SP_LB;
import FBXX.FC.FB_FC_XZL_LB;
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
        findViewById(R.id.ivBACK).setOnClickListener(this);
        findViewById(R.id.llZZ).setOnClickListener(this);
        findViewById(R.id.llHZ).setOnClickListener(this);
        findViewById(R.id.llESF).setOnClickListener(this);
        findViewById(R.id.llSP).setOnClickListener(this);
        findViewById(R.id.llXZL).setOnClickListener(this);
        findViewById(R.id.llCF).setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("FB_Main");
                break;
            case R.id.llZZ:
                YMTZ("FB_FC_ZZ");
                break;
            case R.id.llHZ:
                YMTZ("FB_FC_HZ");
                break;
            case R.id.llESF:
                YMTZ("FB_FC_ESF");
                break;
            case R.id.llSP:
                YMTZ("FB_FC_SP");
                break;
            case R.id.llXZL:
                YMTZ("FB_FC_XZL");
                break;
            case R.id.llCF:
                YMTZ("FB_FC_QT");
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
        if (id == "FB_FC_ZZ") {
            Intent intent = new Intent(FB_FC.this, FB_FC_ZZ.class);
            intent.putExtra("YMMC", "FB_FC");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_HZ") {
            Intent intent = new Intent(FB_FC.this, FB_FC_HZ.class);
            intent.putExtra("YMMC", "FB_FC");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_ESF") {
            Intent intent = new Intent(FB_FC.this, FB_FC_ESF.class);
            intent.putExtra("YMMC", "FB_FC");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_SP") {
            Intent intent = new Intent(FB_FC.this, FB_FC_SP_LB.class);
            intent.putExtra("YMMC", "FB_FC");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_XZL") {
            Intent intent = new Intent(FB_FC.this, FB_FC_XZL_LB.class);
            intent.putExtra("YMMC", "FB_FC");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_QT") {
            Intent intent = new Intent(FB_FC.this, FB_FC_QT_LB.class);
            intent.putExtra("YMMC", "FB_FC");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
