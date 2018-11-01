package COMMON;

import android.annotation.TargetApi;
import android.app.Activity;
import android.content.ContentUris;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.DocumentsContract;
import android.provider.MediaStore;
import android.util.Base64;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import com.example.administrator.Public.R;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Base extends Activity {

    public static String YHM;
    public static String JSESSIONID; //定义一个静态的字段，保存sessionID
    private Uri imageUri;
    private String photoPath;
    private String bitmapToString;
    private Bitmap bitmap;
    public ImageView img_fengmian;
    private static final int IMAGE_REQUEST_CODE = 0;
    private static final int CAMERA_REQUEST_CODE = 1;
    private static final int RESULT_REQUEST_CODE = 2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

//    @Override
//    public void finish() {
//        super.finish();
//        //overridePendingTransitionExit();
//    }
//
//    @Override
//    public void startActivity(Intent intent) {
//        super.startActivity(intent);
//        //overridePendingTransitionEnter();
//    }

//    //Overrides the pending Activity transition by performing the "Enter" animation.
//    protected void overridePendingTransitionEnter() {
//        overridePendingTransition(R.anim.slide_right_in, R.anim.slide_left_out);
//    }
//
//    //Overrides the pending Activity transition by performing the "Exit" animation.
//    protected void overridePendingTransitionExit() {
//        overridePendingTransition(R.anim.slide_left_in, R.anim.slide_right_out);
//    }

    //时间转换
    public String strToDateLong(String strDate) {
        strDate = strDate.replace("/Date(", "").replace(")/", "");
        Date date = new Date(Long.parseLong(strDate));
        SimpleDateFormat format = new SimpleDateFormat("MM月dd日");
        return format.format(date);
    }

    //获取网站资源图片
    public static Bitmap getHttpBitmap(String url) {
        URL myFileURL;
        Bitmap bitmap = null;
        try {
            myFileURL = new URL(url);
            //获得连接
            HttpURLConnection conn = (HttpURLConnection) myFileURL.openConnection();
            //设置超时时间为6000毫秒，conn.setConnectionTiem(0);表示没有时间限制
            conn.setConnectTimeout(6000);
            //连接设置获得数据流
            conn.setDoInput(true);
            //不使用缓存
            conn.setUseCaches(false);
            //得到数据流
            InputStream is = conn.getInputStream();
            //解析得到图片
            bitmap = BitmapFactory.decodeStream(is);
            //关闭数据流
            is.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return bitmap;
    }

    //重置底部菜单
    public void resetBottomMenu() {
        ImageView ivsy_sy = (ImageView) findViewById(R.id.ivSY);
        ivsy_sy.setImageResource(R.drawable.dbcd_sy);
        ImageView ivsy_fb = (ImageView) findViewById(R.id.ivFB);
        ivsy_fb.setImageResource(R.drawable.dbcd_fb);
        ImageView ivsy_xx = (ImageView) findViewById(R.id.ivXX);
        ivsy_xx.setImageResource(R.drawable.dbcd_xx);
        ImageView ivsy_grzx = (ImageView) findViewById(R.id.ivGRZX);
        ivsy_grzx.setImageResource(R.drawable.dbcd_grzx);
    }

    //获取所有子元素
    public static List<View> getAllChildViews(View view) {
        List<View> allchildren = new ArrayList<View>();
        if (view instanceof ViewGroup) {
            ViewGroup vp = (ViewGroup) view;
            for (int i = 0; i < vp.getChildCount(); i++) {
                View viewchild = vp.getChildAt(i);
                allchildren.add(viewchild);
                //再次 调用本身（递归）
                allchildren.addAll(getAllChildViews(viewchild));
            }
        }
        return allchildren;
    }
}
