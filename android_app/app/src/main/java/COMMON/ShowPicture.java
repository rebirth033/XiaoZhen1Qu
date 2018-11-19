package Common;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import com.example.administrator.Public.R;

public class ShowPicture extends Base implements View.OnClickListener {

    private ImageView mivBACK;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.showpicture);
        Intent intent = getIntent();
        ImageView iv = (ImageView) findViewById(R.id.image);
        Bitmap bitmap = BitmapFactory.decodeFile(intent.getStringExtra("imagePath"));
        iv.setImageBitmap(bitmap);
        initView();
    }

    private void initView() {
        mivBACK = (ImageView) findViewById(R.id.iv_back);
        mivBACK.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("SelectPicture");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "SelectPicture") {
            Intent intent = new Intent(ShowPicture.this, EditPicture.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
