package LBCX;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

import COMMON.Base;
import com.example.administrator.Public.R;

public class SY_SHFW extends Base implements View.OnClickListener {

    private ImageView mivBACK;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sy_shfw);
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
            Intent intent = new Intent(SY_SHFW.this,SY_Main.class);
            finish();//关闭当前页面
        }
    }
}
