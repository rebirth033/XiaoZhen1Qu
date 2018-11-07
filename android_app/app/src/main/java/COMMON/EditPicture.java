package COMMON;

import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import FBXX.FC.FB_FC_ZZ;

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

                finish();
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "SelectPicture") {
            List<View> editlist = Base.getAllChildViews(mllpictures);
            spWindow = new SelectPicture(EditPicture.this, spOnClick, editlist);
            spWindow.showAtLocation(EditPicture.this.findViewById(R.id.editpicture), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
    }

    //照片选择页面按钮监听
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
}