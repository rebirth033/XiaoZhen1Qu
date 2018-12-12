package FBXX.CL;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import com.example.administrator.Public.R;
import Common.Base;
import Custom.CustomEditText;

public class FB_CL_JC_CKMS extends Base implements View.OnClickListener {

    private ImageView mivback;
    public TextView mtvsave;
    public CustomEditText mcetckms;
    private String YMMC;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_cl_jc_ckms);
        Intent intent  = this.getIntent();
        YMMC = intent.getStringExtra("YMMC");
        initView();
    }

    //初始化页面
    private void initView() {
        mivback = (ImageView) findViewById(R.id.iv_back);
        mtvsave = (TextView) findViewById(R.id.tv_save);
        mcetckms = (CustomEditText) findViewById(R.id.et_content_middle_ckms);

        mivback.setOnClickListener(this);
        mtvsave.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_CL_JC2");
                break;
            case R.id.tv_save:
                if(YMMC.indexOf("FB_CL_GCC") != -1)
                    YMTZ("FB_CL_GCC_SAVE");
                if(YMMC.indexOf("FB_CL_JC2") != -1)
                    YMTZ("FB_CL_JC2_SAVE");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC_HZ2") {
            Intent intent = new Intent(FB_CL_JC_CKMS.this, FB_CL_JC2.class);
            startActivity(intent);
        }
        if (id == "FB_CL_JC2_SAVE") {
            Intent intent = new Intent(FB_CL_JC_CKMS.this, FB_CL_JC2.class);
            intent.putExtra("YMMC", "FB_CL_CKMS");//设置参数
            intent.putExtra("CKMS", mcetckms.getText());//设置参数
            startActivity(intent);
        }
        if (id == "FB_CL_GCC_SAVE") {
            Intent intent = new Intent(FB_CL_JC_CKMS.this, FB_CL_GCC.class);
            intent.putExtra("YMMC", "FB_CL_CKMS");//设置参数
            intent.putExtra("CKMS", mcetckms.getText());//设置参数
            startActivity(intent);
        }
    }
}
