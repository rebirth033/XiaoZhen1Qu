package COMMON;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.provider.MediaStore;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.RelativeLayout;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.io.ByteArrayOutputStream;
import java.util.List;

public class SelectPicture extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    public LinearLayout mllselectpictures;
    public LinearLayout mlleditpictures;
    public TextView mtvwc;

    public SelectPicture(Activity context, View.OnClickListener itemsOnClick, List<View> editlist) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.selectpicture, null);

        //设置SelectPicPopupWindow的View
        this.setContentView(mMenuView);
        //设置SelectPicPopupWindow弹出窗体的宽
        this.setWidth(ViewGroup.LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体的高
        this.setHeight(ViewGroup.LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体可点击
        this.setFocusable(true);
        //设置SelectPicPopupWindow弹出窗体动画效果
        this.setAnimationStyle(R.style.AnimBottom);
        //实例化一个ColorDrawable颜色为不透明
        ColorDrawable dw = new ColorDrawable(0xFFFFFFFF);
        //设置SelectPicPopupWindow弹出窗体的背景
        this.setBackgroundDrawable(dw);

        //初始化页面
        initView(itemsOnClick,context);
        //获得手机中所有图片的路径
        getAllImagePath(context,editlist);
    }


    //初始化页面
    private void initView(View.OnClickListener itemsOnClick, Activity context){
        mllselectpictures = (LinearLayout) mMenuView.findViewById(R.id.ll_selectpicture_body);
        mlleditpictures = (LinearLayout) mMenuView.findViewById(R.id.ll_editpicture_body);
        mtvwc = (TextView) mMenuView.findViewById(R.id.button_wc);
        mtvwc.setOnClickListener(itemsOnClick);
    }

    //事件监听
    public void onClick(View view) {
//        switch (view.getId()) {
//            case R.id.button_wc:
//
//                break;
//        }
    }

    //获得所有图片的路径
    private void getAllImagePath(Activity context, List<View> editlist) {
        Cursor cursor = context.getContentResolver().query(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, null, null, null, null);
        //遍历相册
        while (cursor.moveToNext()) {
            String path = cursor.getString(cursor.getColumnIndex(MediaStore.MediaColumns.DATA));
            //将图片路径添加到集合
            diaplayImage(path, context, editlist);
        }
        cursor.close();
    }

    //显示图片
    private void diaplayImage(final String imagePath, final Activity context, List<View> editlist){
        if (imagePath != null){
            Bitmap bitmap = BitmapFactory.decodeFile(imagePath);
            RelativeLayout rlimg = new RelativeLayout(context);
            rlimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
            ImageView ivimg = new ImageView(context);
            ivimg.setLayoutParams(new ViewGroup.LayoutParams(360, 360));
            ivimg.setScaleType(ImageView.ScaleType.FIT_XY);
            Drawable drawable = new BitmapDrawable(bitmap);
            ivimg.setImageDrawable(drawable);
            ivimg.setTag(imagePath);
            Drawable.ConstantState t1 = ivimg.getDrawable().getCurrent().getConstantState();
            ivimg.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent(context, ShowPicture.class);
                    intent.putExtra("imagePath", imagePath);
                    context.startActivity(intent);
                    context.finish();//关闭当前页面
                }
            });

            ImageView ivzz = new ImageView(context);
            ivzz.setLayoutParams(new ViewGroup.LayoutParams(360, 360));

            ImageView ivselect = new ImageView(context);
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

            //判断图片是否已经选择
            for (int i = 0; i < editlist.size(); i++) {
                if (editlist.get(i).getClass().toString().contains("RelativeLayout")) {
                    List<View> vs = Base.getAllChildViews(editlist.get(i));
                    ImageView iv = (ImageView) vs.get(0);
                    String tag1 = (String)ivimg.getTag();
                    String tag2 = (String)iv.getTag();
                    if (tag1.equals(tag2)) {
                        ivselect.setImageResource(R.drawable.select);
                        ivselect.setTag(R.drawable.select);
                    }
                }
            }

            rlimg.addView(ivimg);
            rlimg.addView(ivzz);
            rlimg.addView(ivselect);
            mllselectpictures.addView(rlimg);
        }
    }
}
