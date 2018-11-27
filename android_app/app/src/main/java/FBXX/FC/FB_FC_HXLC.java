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

public class FB_FC_HXLC extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllts; //厅室
    private ViewGroup mlllc; //楼层
    public TextView mtvts; //厅室
    public TextView mtvlc; //楼层
    private TabLayout.Tab tabts; //厅室
    private TabLayout.Tab tablc; //楼层
    private TextView mtvtsqd; //厅室
    private TextView mtvlcqd; //楼层
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvs;//室
    public WheelView mwvt;//厅
    public WheelView mwvw;//卫
    public WheelView mwvc;//层
    public WheelView mwvgjc;//共几层

    public FB_FC_HXLC(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_hxlc, null);
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

    //初始化页面
    private void initView(View.OnClickListener itemsOnClick, Activity context, String type) {

        mllts = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_ts);
        mlllc = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_lc);
        mtvts = (TextView) mMenuView.findViewById(R.id.tv_fwqk_ts);
        mtvlc = (TextView) mMenuView.findViewById(R.id.tv_fwqk_lc);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllts.setOnClickListener(this);
        mlllc.setOnClickListener(this);

        tabts = mtbbody.newTab().setCustomView(mllts);
        tablc = mtbbody.newTab().setCustomView(mlllc);
        mtbbody.addTab(tabts);
        mtbbody.addTab(tablc);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vts = inflater.inflate(R.layout.fragment_ts, null);
        View vlc = inflater.inflate(R.layout.fragment_lc, null);
        viewList.add(vts);
        viewList.add(vlc);

        mwvs = (WheelView) vts.findViewById(R.id.wvs);
        mwvt = (WheelView) vts.findViewById(R.id.wvt);
        mwvw = (WheelView) vts.findViewById(R.id.wvw);
        mwvc = (WheelView) vlc.findViewById(R.id.wvc);
        mwvgjc = (WheelView) vlc.findViewById(R.id.wvgjc);

        mtvtsqd = (TextView) vts.findViewById(R.id.tv_ts_qd);
        mtvlcqd = (TextView) vlc.findViewById(R.id.tv_lc_qd);

        mtvtsqd.setOnClickListener(this);
        mtvlcqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "TS")
            mllts.performClick();
        if(type == "LC")
            mlllc.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_fwqk_ts:
                mtvts.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvts.setTextColor(Color.parseColor("#bc6ba6"));
                mtvlc.setHintTextColor(Color.parseColor("#999999"));
                mtvlc.setTextColor(Color.parseColor("#000000"));
                tabts.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.ll_fwqk_lc:
                mtvts.setHintTextColor(Color.parseColor("#999999"));
                mtvts.setTextColor(Color.parseColor("#000000"));
                mtvlc.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvlc.setTextColor(Color.parseColor("#bc6ba6"));
                tablc.select();
                mvpbody.setCurrentItem(2);
                break;
            case R.id.tv_ts_qd:
                mtvts.setText(WheelStyle.createSString().get(mwvs.getCurrentItem()) + WheelStyle.createTString().get(mwvt.getCurrentItem()) + WheelStyle.createWString().get(mwvw.getCurrentItem()));
                mlllc.performClick();
                break;
            case R.id.tv_lc_qd:
                mtvlc.setText(WheelStyle.createCString().get(mwvc.getCurrentItem()).replace("层","") + "/" + WheelStyle.createGJCString().get(mwvgjc.getCurrentItem()).replace("共","").replace("层",""));
                mllts.performClick();
                break;
        }
    }
}
