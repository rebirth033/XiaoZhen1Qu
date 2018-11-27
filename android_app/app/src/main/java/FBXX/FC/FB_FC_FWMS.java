package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.administrator.Public.R;
import Common.Base;
import Custom.CustomEditText;

public class FB_FC_FWMS extends Base implements View.OnClickListener {

    private ImageView mivback;
    public TextView mtvsave;
    public CustomEditText mcetfwms;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_fwms);

        initView();
    }

    //初始化页面
    private void initView() {
        mivback = (ImageView) findViewById(R.id.iv_back);
        mtvsave = (TextView) findViewById(R.id.tv_save);
        mcetfwms = (CustomEditText) findViewById(R.id.et_content_middle_bcms);

        mivback.setOnClickListener(this);
        mtvsave.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC_HZ2");
                break;
            case R.id.tv_save:
                YMTZ("FB_FC_HZ2_SAVE");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC_HZ2") {
            Intent intent = new Intent(FB_FC_FWMS.this, FB_FC_HZ2.class);
            startActivity(intent);
        }
        if (id == "FB_FC_HZ2_SAVE") {
            Intent intent = new Intent(FB_FC_FWMS.this, FB_FC_HZ2.class);
            intent.putExtra("YMMC", "FB_FC_FWMS");//设置参数
            intent.putExtra("FWMS", mcetfwms.getText());//设置参数
            startActivity(intent);
        }
    }
}
