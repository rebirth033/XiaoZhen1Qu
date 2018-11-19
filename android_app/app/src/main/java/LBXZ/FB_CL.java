package LBXZ;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import Common.Base;
import com.example.administrator.Public.R;

public class FB_CL extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_cl);
        findById();
    }

    private void findById() {
        ImageView ivBack = (ImageView) findViewById(R.id.ivBACK);
        ivBack.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("FB_Main");
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
    }
}
