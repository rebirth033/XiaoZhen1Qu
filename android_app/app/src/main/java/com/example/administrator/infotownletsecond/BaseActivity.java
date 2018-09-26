package com.example.administrator.infotownletsecond;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.Date;

public class BaseActivity extends Activity implements View.OnClickListener {

    public String YHM;

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

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tvSZCS:
                break;
        }
    }

//    /**
//     * Overrides the pending Activity transition by performing the "Enter" animation.
//     */
//    protected void overridePendingTransitionEnter() {
//        overridePendingTransition(R.anim.slide_right_in, R.anim.slide_left_out);
//    }
//
//    /**
//     * Overrides the pending Activity transition by performing the "Exit" animation.
//     */
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
            //这句可有可无，没有影响
            //conn.connect();
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

    public void resetBottomMenu(){
        ImageView ivsy_sy = (ImageView) findViewById(R.id.ivSY);
        ivsy_sy.setImageResource(R.drawable.dbcd_sy);
        ImageView ivsy_fb = (ImageView) findViewById(R.id.ivFB);
        ivsy_fb.setImageResource(R.drawable.dbcd_fb);
        ImageView ivsy_xx = (ImageView) findViewById(R.id.ivXX);
        ivsy_xx.setImageResource(R.drawable.dbcd_xx);
        ImageView ivsy_grzx = (ImageView) findViewById(R.id.ivGRZX);
        ivsy_grzx.setImageResource(R.drawable.dbcd_grzx);
    }
}
