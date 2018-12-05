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

import Common.ViewAdapter;
import Common.WheelView;

public class FB_FC_QT_LX extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mlllx; //类型
    public TextView mtvlx; //类型
    private TabLayout.Tab tablx; //类型
    private TextView mtvlxqd; //类型
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvlx;//类型

    public FB_FC_QT_LX(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_qt_lx, null);
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
        initView(itemsOnClick,context);
    }

    private void initView(View.OnClickListener itemsOnClick, Activity context) {

        mlllx = (ViewGroup) mMenuView.findViewById(R.id.lllx);
        mtvlx = (TextView) mMenuView.findViewById(R.id.tv_qt_lx);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mlllx.setOnClickListener(this);

        tablx = mtbbody.newTab().setCustomView(mlllx);
        mtbbody.addTab(tablx);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vlx = inflater.inflate(R.layout.fragment_qtlx, null);
        viewList.add(vlx);

        mwvlx = (WheelView) vlx.findViewById(R.id.wvqtlx);

        mtvlxqd = (TextView) vlx.findViewById(R.id.tv_qtlx_qd);

        mtvlxqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        mlllx.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.lllx:
                mtvlx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvlx.setTextColor(Color.parseColor("#bc6ba6"));
                tablx.select();
                mvpbody.setCurrentItem(0);
                break;
        }
    }
}
