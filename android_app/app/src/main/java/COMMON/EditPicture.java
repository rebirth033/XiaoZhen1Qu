package COMMON;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.PixelFormat;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Base64;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;
import com.example.administrator.Public.R;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import java.io.ByteArrayOutputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class EditPicture extends Base implements View.OnClickListener {

    private ArrayList<HashMap<String, Object>> imageItem;
    private SelectPicture spWindow;
    public LinearLayout mllpictures;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.editpicture);
        initView();
        displayAddImage();
    }

    //初始化页面
    private void initView() {
        TextView tv_wc = (TextView) findViewById(R.id.tv_editpicture_wc);
        mllpictures = (LinearLayout) findViewById(R.id.ll_editpicture_body);
        tv_wc.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tv_editpicture_wc:
                List<View> viewList = Base.getAllChildViews(mllpictures);
                for(int i = 0; i < viewList.size(); i++) {
                    if (viewList.get(i).getClass().toString().contains("RelativeLayout")) {
                        List<View> vs = Base.getAllChildViews(viewList.get(i));
                        ImageView iv = (ImageView) vs.get(0);
                        UploadPicture(iv);
                    }
                }
                finish();
                break;
        }
    }

    //上传照片
    public void UploadPicture(final ImageView iv) {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    String JResult = result.toString();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/Areas/Business/Ashx/SavePhotos.Ashx";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair Filedata = new BasicNameValuePair("Filedata", bitmapToString(drawableToBitmap(iv.getDrawable())));
                    NameValuePair width = new BasicNameValuePair("width", Integer.toString(iv.getWidth()));
                    NameValuePair height = new BasicNameValuePair("height", Integer.toString(iv.getHeight()));
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(Filedata);
                    parameters.add(width);
                    parameters.add(height);
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();
                    if (null != JSESSIONID) httpRequest.setHeader("Cookie", "ASP.NET_SessionId=" + JSESSIONID);

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

    //页面跳转
    public void YMTZ(String id) {
        if (id == "SelectPicture") {
            List<View> editlist = Base.getAllChildViews(mllpictures);
            spWindow = new SelectPicture(EditPicture.this, spOnClick, editlist);
            spWindow.showAtLocation(EditPicture.this.findViewById(R.id.editpicture), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
    }

    //显示图片
    private void diaplayImage(Drawable drawable, String tag) {
        if (drawable != null) {
            RelativeLayout rlimg = new RelativeLayout(this);
            rlimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
            ImageView ivimg = new ImageView(this);
            ivimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
            ivimg.setScaleType(ImageView.ScaleType.FIT_XY);
            ivimg.setImageDrawable(drawable);
            ivimg.setTag(tag);
            ivimg.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
//                    Intent intent = new Intent(this, ShowPicture.class);
//                    intent.putExtra("imagePath", imagePath);
//                    startActivity(intent);
//                    finish();//关闭当前页面
                }
            });

            ImageView ivzz = new ImageView(this);
            ivzz.setLayoutParams(new ViewGroup.LayoutParams(360, 360));

            ImageView ivdelete = new ImageView(this);
            ivdelete.setLayoutParams(new ViewGroup.LayoutParams(75, 75));
            ivdelete.setImageResource(R.drawable.delete);
            ivdelete.setTag(R.drawable.delete);
            ivdelete.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    ImageView iv = (ImageView) v;
                    View parentview = (View) v.getParent();
                    mllpictures.removeView(parentview);
                }
            });
            rlimg.addView(ivimg);
            rlimg.addView(ivzz);
            rlimg.addView(ivdelete);
            mllpictures.addView(rlimg);
        }
    }

    //显示添加按钮
    private void displayAddImage(){
        LinearLayout rlimg = new LinearLayout(this);
        rlimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
        ImageView ivimg = new ImageView(this);
        ivimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
        ivimg.setScaleType(ImageView.ScaleType.FIT_XY);
        ivimg.setImageResource(R.drawable.add);
        rlimg.addView(ivimg);
        rlimg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                YMTZ("SelectPicture");
            }
        });
        mllpictures.addView(rlimg);
    }

    //把bitmap转换成字符串
    public String bitmapToString(Bitmap bitmap) {
        String string = null;
        ByteArrayOutputStream btString = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, btString);
        byte[] bytes = btString.toByteArray();
        string = Base64.encodeToString(bytes, Base64.DEFAULT);
        return string;
    }

    //Drawable转Bitmap
    public Bitmap drawableToBitmap(Drawable drawable) {
        // 取 drawable 的长宽
        int w = drawable.getIntrinsicWidth();
        int h = drawable.getIntrinsicHeight();

        // 取 drawable 的颜色格式
        Bitmap.Config config = drawable.getOpacity() != PixelFormat.OPAQUE ? Bitmap.Config.ARGB_8888
                : Bitmap.Config.RGB_565;
        // 建立对应 bitmap
        Bitmap bitmap = Bitmap.createBitmap(w, h, config);
        // 建立对应 bitmap 的画布
        Canvas canvas = new Canvas(bitmap);
        drawable.setBounds(0, 0, w, h);
        // 把 drawable 内容画到画布中
        drawable.draw(canvas);
        return bitmap;
    }

    //region 照片选择页面按钮监听
    private View.OnClickListener spOnClick = new View.OnClickListener() {
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.button_wc:
                    mllpictures.removeAllViews();
                    List<View> viewList = Base.getAllChildViews(spWindow.mllselectpictures);
                    for(int i = 0; i < viewList.size(); i++) {
                        if (viewList.get(i).getClass().toString().contains("RelativeLayout")) {
                            List<View> vs = Base.getAllChildViews(viewList.get(i));
                            ImageView iv = (ImageView) vs.get(2);
                            int res = (int) iv.getTag();
                            if (res == R.drawable.select) {
                                ImageView iv_zp = (ImageView) vs.get(0);
                                diaplayImage(iv_zp.getDrawable(),(String)iv_zp.getTag());
                            }
                        }
                    }
                    displayAddImage();
                    spWindow.dismiss();
                    break;
            }
        }
    };
    //endregion
}