package FBXX.FC;

import com.example.administrator.Public.R;
import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.PopupWindow;
import android.widget.TextView;
import java.util.ArrayList;
import java.util.List;

public class FB_FC_CWDT extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllcw; //车位
    private ViewGroup mlldt; //电梯
    public TextView mtvcw; //车位
    public TextView mtvdt; //电梯
    private TabLayout.Tab tabcw; //车位
    private TabLayout.Tab tabdt; //电梯
    private TextView mtvcwqd; //车位
    private TextView mtvdtqd; //电梯
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvcw;//车位
    public WheelView mwvdt;//电梯

    public FB_FC_CWDT(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_cwdt, null);
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
        //实例化一个ColorDrawable颜色为半透明
        ColorDrawable dw = new ColorDrawable(0xb0000000);
        //设置SelectPicPopupWindow弹出窗体的背景
        this.setBackgroundDrawable(dw);
        //初始化页面
        initView(itemsOnClick,context, type);
    }

    private void initView(View.OnClickListener itemsOnClick, Activity context, String type) {

        mllcw = (ViewGroup) mMenuView.findViewById(R.id.llcw);
        mlldt = (ViewGroup) mMenuView.findViewById(R.id.lldt);
        mtvcw = (TextView) mMenuView.findViewById(R.id.tv_cw);
        mtvdt = (TextView) mMenuView.findViewById(R.id.tv_dt);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllcw.setOnClickListener(this);
        mlldt.setOnClickListener(this);

        tabcw = mtbbody.newTab().setCustomView(mllcw);
        tabdt = mtbbody.newTab().setCustomView(mlldt);
        mtbbody.addTab(tabcw);
        mtbbody.addTab(tabdt);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vcw = inflater.inflate(R.layout.fragment_cw, null);
        View vdt = inflater.inflate(R.layout.fragment_dt, null);
        viewList.add(vcw);
        viewList.add(vdt);

        mwvcw = (WheelView) vcw.findViewById(R.id.wvcw);
        mwvdt = (WheelView) vdt.findViewById(R.id.wvdt);

        mtvcwqd = (TextView) vcw.findViewById(R.id.tv_cw_qd);
        mtvdtqd = (TextView) vdt.findViewById(R.id.tv_dt_qd);

        mtvcwqd.setOnClickListener(this);
        mtvdtqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        mllcw.performClick();

        if(type == "CW")
            mllcw.performClick();
        if(type == "DT")
            mlldt.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llcw:
                mtvcw.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvcw.setTextColor(Color.parseColor("#bc6ba6"));
                mtvdt.setHintTextColor(Color.parseColor("#999999"));
                mtvdt.setTextColor(Color.parseColor("#000000"));
                tabcw.select();
                mvpbody.setCurrentItem(0);
                mwvcw.setWheelItemList(WheelStyle.createCWString());
                break;
            case R.id.lldt:
                mtvcw.setHintTextColor(Color.parseColor("#999999"));
                mtvcw.setTextColor(Color.parseColor("#000000"));
                mtvdt.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvdt.setTextColor(Color.parseColor("#000000"));
                tabdt.select();
                mvpbody.setCurrentItem(1);
                mwvdt.setWheelItemList(WheelStyle.createDTString());
                break;
            case R.id.tv_cw_qd:
                mtvcw.setText(WheelStyle.createCWString().get(mwvcw.getCurrentItem()));
                mlldt.performClick();
                break;
        }
    }
}
