package LBXZ;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import Common.Base;
import FBXX.CL.FB_CL_GCC;
import FBXX.CL.FB_CL_JC;
import com.example.administrator.Public.R;

public class FB_CL extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_cl);
        findById();
    }

    private void findById() {
        findViewById(R.id.ivBACK).setOnClickListener(this);
        findViewById(R.id.llESC).setOnClickListener(this);
        findViewById(R.id.llGCC).setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("FB_Main");
                break;
            case R.id.llESC:
                YMTZ("FB_CL_JC");
                break;
            case R.id.llGCC:
                YMTZ("FB_CL_GCC");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "FB_Main") {
            Intent intent = new Intent(FB_CL.this, FB_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_CL_JC") {
            Intent intent = new Intent(FB_CL.this, FB_CL_JC.class);
            intent.putExtra("YMMC", "FB_CL");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_CL_GCC") {
            Intent intent = new Intent(FB_CL.this, FB_CL_GCC.class);
            intent.putExtra("YMMC", "FB_CL");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
