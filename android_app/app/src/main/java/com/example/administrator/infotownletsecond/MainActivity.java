package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.content.Context;
import android.os.StrictMode;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.util.DisplayMetrics;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.baidu.location.BDLocation;
import com.baidu.location.BDLocationListener;
import com.baidu.location.LocationClient;
import com.baidu.location.Poi;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import android.support.v4.app.FragmentPagerAdapter;

public class MainActivity extends AppCompatActivity implements OnClickListener {
    private static Context context;
    private TextView mtvSZCS;
    private LinearLayout mllWZJX;
    private ViewPager mvpDH;
    private List<Fragment> mFragmentList = new ArrayList<Fragment>();

    private LocationClient mLocationClient;// 定位SDK的核心类

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        findById();
        init();
        //HQDQSZD();
        //GetWZJX();
    }

    private void findById() {
        mtvSZCS = (TextView) findViewById(R.id.tvSZCS);
        mllWZJX = (LinearLayout) findViewById(R.id.llWZJX);
        ViewGroup vgfb = (ViewGroup) findViewById(R.id.llFB);
        ViewGroup vgxx = (ViewGroup) findViewById(R.id.llXX);
        ViewGroup vggrzx = (ViewGroup) findViewById(R.id.llGRZX);
        vgfb.setOnClickListener(this);
        vgxx.setOnClickListener(this);
        vggrzx.setOnClickListener(this);
    }

    private void init() {
        //解决获取网站资源图片报错问题
        StrictMode.setThreadPolicy(new StrictMode.ThreadPolicy.Builder().detectDiskReads().detectDiskWrites().detectNetwork().penaltyLog().build());
        StrictMode.setVmPolicy(new StrictMode.VmPolicy.Builder().detectLeakedSqlLiteObjects().detectLeakedClosableObjects().penaltyLog().penaltyDeath().build());
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llSY:
                YMTZ("SY");
                break;
            case R.id.llFB:
                YMTZ("FB");
                break;
            case R.id.llXX:
                YMTZ("XX");
                break;
            case R.id.llGRZX:
                YMTZ("GRZX");
                break;
            case R.id.tvSZCS:

                break;
        }
    }

    //网站精选
    public void GetWZJX() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerWZJX(JList);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/FCCX/LoadFCXXWithoutXZQ";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair TYPE = new BasicNameValuePair("TYPE", "FCXX_ZZF");
                    NameValuePair Condition = new BasicNameValuePair("Condition", "STATUS:1,ISHOT:1");
                    NameValuePair PageIndex = new BasicNameValuePair("PageIndex", "1");
                    NameValuePair PageSize = new BasicNameValuePair("PageSize", "10");
                    NameValuePair XZQ = new BasicNameValuePair("XZQ", "福州");
                    NameValuePair XZQDM = new BasicNameValuePair("XZQDM", "350100");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(TYPE);
                    parameters.add(Condition);
                    parameters.add(PageIndex);
                    parameters.add(PageSize);
                    parameters.add(XZQ);
                    parameters.add(XZQDM);
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();

                    HttpResponse response = httpClient.execute(httpRequest); //发起GET请求
                    int rescode = response.getStatusLine().getStatusCode(); //获取响应码
                    result = EntityUtils.toString(response.getEntity(), "utf-8");//获取服务器响应内容
                } catch (Exception e) {
                    e.printStackTrace();
                }
                return result;
            }
        }.execute();
    }

    //处理网站精选
    public void HandlerWZJX(String JList) {
        try {
            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < jsonarray.length(); i++) {
                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String BT = jsonObject.getString("BT");
                String ZXGXSJ = jsonObject.getString("ZXGXSJ");
                JSONArray photoarray = new JSONArray(jsonObject.getString("PHOTOS"));
                JSONObject photoObject = photoarray.getJSONObject(0);

                LinearLayout llouter = new LinearLayout(this);
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 400);
                llouter.setLayoutParams(layoutParams);
                mllWZJX.addView(llouter);

                ImageView ivtp = new ImageView(this);
                ivtp.setLayoutParams(new ViewGroup.LayoutParams(440, 340));
                ivtp.setScaleType(ImageView.ScaleType.FIT_XY);
                ivtp.setPadding(20, 0, 20, 20);
                //显示在界面上
                ivtp.setImageBitmap(getHttpBitmap(photoObject.getString("PHOTOURL")));

                LinearLayout llinner = new LinearLayout(this);
                llinner.setOrientation(LinearLayout.VERTICAL);

                TextView tvbt = new TextView(this);
                tvbt.setWidth(800);
                tvbt.setHeight(240);
                tvbt.setText(BT);

                TextView tvgxsj = new TextView(this);
                tvgxsj.setWidth(800);
                tvgxsj.setHeight(150);
                tvgxsj.setText(strToDateLong(ZXGXSJ));

                llinner.addView(tvbt);
                llinner.addView(tvgxsj);
                llouter.addView(ivtp);
                llouter.addView(llinner);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
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

    //时间转换
    public String strToDateLong(String strDate) {
        strDate = strDate.replace("/Date(", "").replace(")/", "");
        Date date = new Date(Long.parseLong(strDate));
        SimpleDateFormat format = new SimpleDateFormat("MM月dd日");
        return format.format(date);
    }

    //跳转登录页
    public void TZDLY() {
        Intent intent = new Intent(MainActivity.this, YHDLActivity.class);
        startActivity(intent);
        finish();//关闭当前页面
    }

    //个人中心
    public void YMTZ(String id) {
        if(id == "FB") {
            Intent intent = new Intent(MainActivity.this, FBActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "XX") {
            Intent intent = new Intent(MainActivity.this, XXActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "GRZX") {
            Intent intent = new Intent(MainActivity.this, GRZXActivity.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }

    //获取当前所在地
    public void HQDQSZD() {
        MainActivity.context = getApplicationContext();
        LocationService.getInstance(MainActivity.context).start();
        LocationService.getInstance(MainActivity.context).registerListener(new MyLocationListener());// 注册监听函数
    }

    //定位监听
    public class MyLocationListener implements BDLocationListener {
        @Override
        public void onReceiveLocation(BDLocation location) {

            if (null != location) {
                StringBuffer sb = new StringBuffer(256);
                sb.append("time : ");
                /**
                 * 时间也可以使用systemClock.elapsedRealtime()方法 获取的是自从开机以来，每次回调的时间；
                 * location.getTime() 是指服务端出本次结果的时间，如果位置不发生变化，则时间不变
                 */
                sb.append(location.getTime());
                sb.append("\nlocType : ");// 定位类型
                sb.append(location.getLocType());
                sb.append("\nlocType description : ");// *****对应的定位类型说明*****
                //sb.append(location.getLocTypeDescription());
                sb.append("\nlatitude : ");// 纬度
                sb.append(location.getLatitude());
                sb.append("\nlontitude : ");// 经度
                sb.append(location.getLongitude());
                sb.append("\nradius : ");// 半径
                sb.append(location.getRadius());
                sb.append("\nCountryCode : ");// 国家码
                sb.append(location.getCountryCode());
                sb.append("\nCountry : ");// 国家名称
                sb.append(location.getCountry());
                sb.append("\ncitycode : ");// 城市编码
                sb.append(location.getCityCode());
                sb.append("\ncity : ");// 城市
                sb.append(location.getCity());
                sb.append("\nDistrict : ");// 区
                sb.append(location.getDistrict());
                sb.append("\nStreet : ");// 街道
                sb.append(location.getStreet());
                sb.append("\naddr : ");// 地址信息
                sb.append(location.getAddrStr());
                sb.append("\nUserIndoorState: ");// *****返回用户室内外判断结果*****
                //sb.append(location.getUserIndoorState());
                sb.append("\nDirection(not all devices have value): ");
                sb.append(location.getDirection());// 方向
                sb.append("\nlocationdescribe: ");
                sb.append(location.getLocationDescribe());// 位置语义化信息
                sb.append("\nPoi: ");// POI信息
                if (location.getPoiList() != null && !location.getPoiList().isEmpty()) {
                    for (int i = 0; i < location.getPoiList().size(); i++) {
                        Poi poi = (Poi) location.getPoiList().get(i);
                        sb.append(poi.getName() + ";");
                    }
                }
                if (location.getLocType() == BDLocation.TypeGpsLocation) {// GPS定位结果
                    sb.append("\nspeed : ");
                    sb.append(location.getSpeed());// 速度 单位：km/h
                    sb.append("\nsatellite : ");
                    sb.append(location.getSatelliteNumber());// 卫星数目
                    sb.append("\nheight : ");
                    sb.append(location.getAltitude());// 海拔高度 单位：米
                    sb.append("\ngps status : ");
                    //sb.append(location.getGpsAccuracyStatus());// *****gps质量判断*****
                    sb.append("\ndescribe : ");
                    sb.append("gps定位成功");
                } else if (location.getLocType() == BDLocation.TypeNetWorkLocation) {// 网络定位结果
                    // 运营商信息
                    if (location.hasAltitude()) {// *****如果有海拔高度*****
                        sb.append("\nheight : ");
                        sb.append(location.getAltitude());// 单位：米
                    }
                    sb.append("\noperationers : ");// 运营商信息
                    sb.append(location.getOperators());
                    sb.append("\ndescribe : ");
                    sb.append("网络定位成功");
                } else if (location.getLocType() == BDLocation.TypeOffLineLocation) {// 离线定位结果
                    sb.append("\ndescribe : ");
                    sb.append("离线定位成功，离线定位结果也是有效的");
                } else if (location.getLocType() == BDLocation.TypeServerError) {
                    sb.append("\ndescribe : ");
                    sb.append("服务端网络定位失败，可以反馈IMEI号和大体定位时间到loc-bugs@baidu.com，会有人追查原因");
                } else if (location.getLocType() == BDLocation.TypeNetWorkException) {
                    sb.append("\ndescribe : ");
                    sb.append("网络不同导致定位失败，请检查网络是否通畅");
                } else if (location.getLocType() == BDLocation.TypeCriteriaException) {
                    sb.append("\ndescribe : ");
                    sb.append("无法获取有效定位依据导致定位失败，一般是由于手机的原因，处于飞行模式下一般会造成这种结果，可以试着重启手机");
                }
                mtvSZCS.setText(location.getCity());
                MainActivity.context = getApplicationContext();
                LocationService.getInstance(MainActivity.context).stop();
            } else {
                //tv_location.setText("\n定位失败");
            }
        }
    }
}
