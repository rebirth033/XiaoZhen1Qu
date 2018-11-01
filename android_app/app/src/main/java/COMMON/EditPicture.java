package COMMON;

import android.app.Activity;
import android.content.pm.ActivityInfo;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.SimpleAdapter;
import com.example.administrator.Public.R;
import java.util.ArrayList;
import java.util.HashMap;

public class EditPicture extends Base implements View.OnClickListener {

    private GridView gridView1;              //网格显示缩略图
    private final int IMAGE_OPEN = 1;        //打开图片标记
    private String pathImage;                //选择图片路径
    private Bitmap bmp;                      //导入临时图片
    private ArrayList<HashMap<String, Object>> imageItem;
    private SimpleAdapter simpleAdapter;     //适配器
    private ImageView mivadd;
    private SelectPicture spWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.editpicture);
        //锁定屏幕
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        setContentView(R.layout.editpicture);
        initView();
    }

    //初始化页面
    private void initView(){
        mivadd = (ImageView) findViewById(R.id.iv_editpicture_add);
        mivadd.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_editpicture_add:
                YMTZ("SelectPicture");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "SelectPicture") {
            //spWindow = new SelectPicture(EditPicture.this, spOnClick);
            //spWindow.showAtLocation(EditPicture.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
    }

}