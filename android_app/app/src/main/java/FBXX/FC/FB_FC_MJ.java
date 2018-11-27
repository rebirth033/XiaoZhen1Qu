package FBXX.FC;

import android.app.Activity;
import android.content.Context;
import android.graphics.drawable.ColorDrawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.PopupWindow;
import android.widget.TextView;
import com.example.administrator.Public.R;

public class FB_FC_MJ extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    public EditText metmj;

    public FB_FC_MJ(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_mj, null);
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

        findById(itemsOnClick);
    }

    private void findById(View.OnClickListener itemsOnClick) {
        TextView mtv0 = (TextView) mMenuView.findViewById(R.id.tv0);
        TextView mtv1 = (TextView) mMenuView.findViewById(R.id.tv1);
        TextView mtv2 = (TextView) mMenuView.findViewById(R.id.tv2);
        TextView mtv3 = (TextView) mMenuView.findViewById(R.id.tv3);
        TextView mtv4 = (TextView) mMenuView.findViewById(R.id.tv4);
        TextView mtv5 = (TextView) mMenuView.findViewById(R.id.tv5);
        TextView mtv6 = (TextView) mMenuView.findViewById(R.id.tv6);
        TextView mtv7 = (TextView) mMenuView.findViewById(R.id.tv7);
        TextView mtv8 = (TextView) mMenuView.findViewById(R.id.tv8);
        TextView mtv9 = (TextView) mMenuView.findViewById(R.id.tv9);
        TextView mtvpoint = (TextView) mMenuView.findViewById(R.id.tvpoint);
        TextView mtvsc = (TextView) mMenuView.findViewById(R.id.tvsc);
        ImageView mivqx = (ImageView) mMenuView.findViewById(R.id.ivqx);
        TextView mtvqd = (TextView) mMenuView.findViewById(R.id.tvqd);
        metmj = (EditText) mMenuView.findViewById(R.id.etmj);
        mtv0.setOnClickListener(this);
        mtv1.setOnClickListener(this);
        mtv2.setOnClickListener(this);
        mtv3.setOnClickListener(this);
        mtv4.setOnClickListener(this);
        mtv5.setOnClickListener(this);
        mtv6.setOnClickListener(this);
        mtv7.setOnClickListener(this);
        mtv8.setOnClickListener(this);
        mtv9.setOnClickListener(this);
        mtvpoint.setOnClickListener(this);
        mtvsc.setOnClickListener(this);
        mivqx.setOnClickListener(itemsOnClick);
        mtvqd.setOnClickListener(itemsOnClick);
        metmj.setOnClickListener(itemsOnClick);
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
        if(metmj.getText().toString() == "")
            metmj.setText(value + "㎡");
        else
            metmj.setText(metmj.getText().toString().replaceAll("㎡","") + value + "㎡");
    }
    //删除
    public void Delete() {
        if(metmj.length() == 2)
            metmj.setText("");
        else
            metmj.setText(metmj.getText().toString().substring(0, metmj.length() - 2) + "㎡");
    }
}
