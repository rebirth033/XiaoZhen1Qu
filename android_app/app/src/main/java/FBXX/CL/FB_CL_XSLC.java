package FBXX.CL;

import android.app.Activity;
import android.content.Context;
import android.graphics.drawable.ColorDrawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.EditText;
import android.widget.PopupWindow;
import com.example.administrator.Public.R;

public class FB_CL_XSLC extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    public EditText metxslc;

    public FB_CL_XSLC(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_cl_xslc, null);
        //设置SelectPicPopupWindow的View
        this.setContentView(mMenuView);
        //设置SelectPicPopupWindow弹出窗体的宽
        this.setWidth(LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体的高
        this.setHeight(LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体可点击
        this.setFocusable(true);
        //设置SelectPicPopupWindow弹出窗体动画效果
        this.setAnimationStyle(R.style.AnimBottom);
        //实例化一个ColorDrawable颜色为半透明
        ColorDrawable dw = new ColorDrawable(0xb0000000);
        //设置SelectPicPopupWindow弹出窗体的背景
        this.setBackgroundDrawable(dw);
        //初始化页面
        initView(itemsOnClick);
    }

    private void initView(View.OnClickListener itemsOnClick) {
        mMenuView.findViewById(R.id.tv0).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv1).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv2).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv3).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv4).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv5).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv6).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv7).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv8).setOnClickListener(this);
        mMenuView.findViewById(R.id.tv9).setOnClickListener(this);
        mMenuView.findViewById(R.id.tvpoint).setOnClickListener(this);
        mMenuView.findViewById(R.id.tvsc).setOnClickListener(this);
        mMenuView.findViewById(R.id.ivqx).setOnClickListener(itemsOnClick);
        mMenuView.findViewById(R.id.tvqd).setOnClickListener(itemsOnClick);
        metxslc = (EditText) mMenuView.findViewById(R.id.etxslc);

        metxslc.setOnClickListener(itemsOnClick);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tv0:
                Input("0");
                break;
            case R.id.tv1:
                Input("1");
                break;
            case R.id.tv2:
                Input("2");
                break;
            case R.id.tv3:
                Input("3");
                break;
            case R.id.tv4:
                Input("4");
                break;
            case R.id.tv5:
                Input("5");
                break;
            case R.id.tv6:
                Input("6");
                break;
            case R.id.tv7:
                Input("7");
                break;
            case R.id.tv8:
                Input("8");
                break;
            case R.id.tv9:
                Input("9");
                break;
            case R.id.tvpoint:
                Input(".");
                break;
            case R.id.tvsc:
                Delete();
                break;
        }
    }

    //输入
    public void Input(String value) {
        if(metxslc.getText().toString() == "")
            metxslc.setText(value + "万公里");
        else
            metxslc.setText(metxslc.getText().toString().replaceAll("万公里","") + value + "万公里");
    }
    //删除
    public void Delete() {
        if(metxslc.length() == 2)
            metxslc.setText("");
        else
            metxslc.setText(metxslc.getText().toString().substring(0, metxslc.length() - 4) + "万公里");
    }
}
