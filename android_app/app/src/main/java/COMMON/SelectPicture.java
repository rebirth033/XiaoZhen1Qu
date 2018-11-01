package COMMON;

import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.provider.MediaStore;
import android.os.Bundle;
import android.util.Base64;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.io.ByteArrayOutputStream;
import java.util.List;

public class SelectPicture extends Base implements View.OnClickListener {

    private LinearLayout mllpictures;
    private TextView mtvwc;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.selectpicture);
        //获得手机中所有图片的路径
        initView();
        getAllImagePath();
    }

    private void initView(){
        mllpictures = (LinearLayout) findViewById(R.id.ll_selectpicture_body);
        mtvwc = (TextView) findViewById(R.id.button_wc);
        mtvwc.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.button_wc:
                YMTZ("EditPicture");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "EditPicture") {
            Intent intent = new Intent(SelectPicture.this, EditPicture.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }

    //获得所有图片的路径
    private void getAllImagePath() {
        Cursor cursor = getContentResolver().query(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, null, null, null, null);
        //遍历相册
        while (cursor.moveToNext()) {
            String path = cursor.getString(cursor.getColumnIndex(MediaStore.MediaColumns.DATA));
            //将图片路径添加到集合
            diaplayImage(path);
        }
        cursor.close();
    }

    //把bitmap转换成字符串
    public static String bitmapToString(Bitmap bitmap) {
        String string = null;
        ByteArrayOutputStream btString = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, btString);
        byte[] bytes = btString.toByteArray();
        string = Base64.encodeToString(bytes, Base64.DEFAULT);
        return string;
    }

    //显示图片
    private void diaplayImage(final String imagePath){
        if (imagePath != null){
            Bitmap bitmap = BitmapFactory.decodeFile(imagePath);
            RelativeLayout rlimg = new RelativeLayout(this);
            rlimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
            ImageView ivimg = new ImageView(this);
            ivimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
            ivimg.setScaleType(ImageView.ScaleType.FIT_XY);
            ivimg.setImageBitmap(bitmap);
            ivimg.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent(SelectPicture.this, ShowPicture.class);
                    intent.putExtra("imagePath", imagePath);
                    startActivity(intent);
                    finish();//关闭当前页面
                }
            });

            ImageView ivzz = new ImageView(this);
            ivzz.setLayoutParams(new ViewGroup.LayoutParams(360, 360));

            ImageView ivselect = new ImageView(this);
            ivselect.setLayoutParams(new ViewGroup.LayoutParams(75, 75));
            ivselect.setImageResource(R.drawable.unselect);
            ivselect.setTag(R.drawable.unselect);
            ivselect.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    ImageView iv = (ImageView)v;
                    int res = (int) iv.getTag();
                    View parentview =  (View)v.getParent();
                    List<View> vs = Base.getAllChildViews(parentview);
                    ImageView zz = (ImageView)vs.get(1);
                    if(res == R.drawable.unselect) {
                        iv.setImageResource(R.drawable.select);
                        iv.setTag(R.drawable.select);
                        zz.setBackgroundColor(0x55000000);
                    }
                    else{
                        iv.setImageResource(R.drawable.unselect);
                        iv.setTag(R.drawable.unselect);
                        zz.setBackgroundColor(0x00000000);
                    }
                }
            });
            rlimg.addView(ivimg);
            rlimg.addView(ivzz);
            rlimg.addView(ivselect);
            mllpictures.addView(rlimg);
        }
    }
}
