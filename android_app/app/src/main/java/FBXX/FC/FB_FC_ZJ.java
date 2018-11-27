package FBXX.FC;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.PopupWindow;
import android.widget.TextView;
import com.example.administrator.Public.R;

public class FB_FC_ZJ extends PopupWindow  implements View.OnClickListener {

    private View mMenuView;
    public EditText metzj;
    private TextView mtvy1f1;
    private TextView mtvy1f3;
    private TextView mtvbnf;
    private TextView mtvnf;
    public String yffs = new String();

    public FB_FC_ZJ(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_zj, null);
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

        initView(itemsOnClick);
    }

    private void initView(View.OnClickListener itemsOnClick) {
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
        mtvy1f1 = (TextView) mMenuView.findViewById(R.id.tvy1f1);
        mtvy1f3 = (TextView) mMenuView.findViewById(R.id.tvy1f3);
        mtvbnf = (TextView) mMenuView.findViewById(R.id.tvbnf);
        mtvnf = (TextView) mMenuView.findViewById(R.id.tvnf);
        ImageView mivqx = (ImageView) mMenuView.findViewById(R.id.ivqx);
        TextView mtvqd = (TextView) mMenuView.findViewById(R.id.tvqd);
        metzj = (EditText) mMenuView.findViewById(R.id.etzj);
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
        mtvy1f1.setOnClickListener(this);
        mtvy1f3.setOnClickListener(this);
        mtvbnf.setOnClickListener(this);
        mtvnf.setOnClickListener(this);
        mivqx.setOnClickListener(itemsOnClick);
        mtvqd.setOnClickListener(itemsOnClick);
        metzj.setOnClickListener(itemsOnClick);
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
            case R.id.tvy1f1:
                SetYFFS("y1f1");
                break;
            case R.id.tvy1f3:
                SetYFFS("y1f3");
                break;
            case R.id.tvbnf:
                SetYFFS("bnf");
                break;
            case R.id.tvnf:
                SetYFFS("nf");
                break;
        }
    }

    //输入
    private void Input(String value) {
        if(metzj.getText().toString() == "")
            metzj.setText(value + "㎡");
        else
            metzj.setText(metzj.getText().toString().replaceAll("元","") + value + "元");
    }
    //删除
    private void Delete() {
        if(metzj.length() == 2)
            metzj.setText("");
        else
            metzj.setText(metzj.getText().toString().substring(0,metzj.length() - 2) + "元");
    }
    //选择押付方式
    private void SetYFFS(String value){
        if(value == "y1f1") {ReSetYFFS();mtvy1f1.setBackgroundColor(Color.parseColor("#bc6ba6"));yffs = "押一付一";}
        if(value == "y1f3") {ReSetYFFS();mtvy1f3.setBackgroundColor(Color.parseColor("#bc6ba6"));yffs = "押一付三";}
        if(value == "bnf") {ReSetYFFS();mtvbnf.setBackgroundColor(Color.parseColor("#bc6ba6"));yffs = "半年付";}
        if(value == "nf") {ReSetYFFS();mtvnf.setBackgroundColor(Color.parseColor("#bc6ba6"));yffs = "年付";}
    }

    private void ReSetYFFS(){
        mtvy1f1.setBackgroundColor(Color.parseColor("#ececec"));
        mtvy1f3.setBackgroundColor(Color.parseColor("#ececec"));
        mtvbnf.setBackgroundColor(Color.parseColor("#ececec"));
        mtvnf.setBackgroundColor(Color.parseColor("#ececec"));
    }
}
