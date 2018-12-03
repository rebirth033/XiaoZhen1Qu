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

public class FB_FC_SP_LC extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mlllc; //楼层
    public TextView mtvlc; //楼层
    private TabLayout.Tab tablc; //楼层
    private TextView mtvlcqd; //楼层
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvc; //层
    public WheelView mwvgjc; //共几层

    public FB_FC_SP_LC(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_sp_lc, null);
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

    //初始化页面
    private void initView(View.OnClickListener itemsOnClick, Activity context) {

        mlllc = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_lc);
        mtvlc = (TextView) mMenuView.findViewById(R.id.tv_fwqk_lc);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mlllc.setOnClickListener(this);

        tablc = mtbbody.newTab().setCustomView(mlllc);

        mtbbody.addTab(tablc);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vlc = inflater.inflate(R.layout.fragment_lc, null);
        viewList.add(vlc);

        mwvc = (WheelView) vlc.findViewById(R.id.wvc);
        mwvgjc = (WheelView) vlc.findViewById(R.id.wvgjc);

        mtvlcqd = (TextView) vlc.findViewById(R.id.tv_lc_qd);

        mtvlcqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        mlllc.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_fwqk_lc:
                mtvlc.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvlc.setTextColor(Color.parseColor("#bc6ba6"));
                tablc.select();
                mvpbody.setCurrentItem(0);
                break;
        }
    }
}
