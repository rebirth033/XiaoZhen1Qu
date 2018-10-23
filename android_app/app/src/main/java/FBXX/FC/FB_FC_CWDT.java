package FBXX.FC;

import com.example.administrator.Public.R;
import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.annotation.NonNull;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.PopupWindow;
import android.widget.TextView;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

public class FB_FC_CWDT extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllts; //厅室
    private ViewGroup mllcx; //朝向
    private ViewGroup mlllc; //楼层
    private TextView tvts; //厅室
    private TextView tvcx; //朝向
    private TextView tvlc; //楼层
    private TabLayout.Tab tabts;
    private TabLayout.Tab tabcx;
    private TabLayout.Tab tablc;

    private ArrayList<Fragment> frag_list;
    private TabLayout mtbbody;
    private ViewPager mvpbody;

    public FB_FC_CWDT(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_fwqk, null);
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

        initView(itemsOnClick,context);
    }

    private void initView(View.OnClickListener itemsOnClick,Activity context) {

        mllts = (ViewGroup) mMenuView.findViewById(R.id.llts);
        mllcx = (ViewGroup) mMenuView.findViewById(R.id.llcx);
        mlllc = (ViewGroup) mMenuView.findViewById(R.id.lllc);
        tvts = (TextView) mMenuView.findViewById(R.id.tvts);
        tvcx = (TextView) mMenuView.findViewById(R.id.tvcx);
        tvlc = (TextView) mMenuView.findViewById(R.id.tvlc);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllts.setOnClickListener(this);
        mllcx.setOnClickListener(this);
        mlllc.setOnClickListener(this);

        tabts = mtbbody.newTab().setCustomView(mllts);
        mtbbody.addTab(tabts);
        tabcx = mtbbody.newTab().setCustomView(mllcx);
        mtbbody.addTab(tabcx);
        tablc = mtbbody.newTab().setCustomView(mlllc);
        mtbbody.addTab(tablc);

        List<View> pages = new List<View>() {
            @Override
            public int size() {
                return 0;
            }

            @Override
            public boolean isEmpty() {
                return false;
            }

            @Override
            public boolean contains(Object o) {
                return false;
            }

            @NonNull
            @Override
            public Iterator<View> iterator() {
                return null;
            }

            @NonNull
            @Override
            public Object[] toArray() {
                return new Object[0];
            }

            @NonNull
            @Override
            public <T> T[] toArray(@NonNull T[] a) {
                return null;
            }

            @Override
            public boolean add(View view) {
                return false;
            }

            @Override
            public boolean remove(Object o) {
                return false;
            }

            @Override
            public boolean containsAll(@NonNull Collection<?> c) {
                return false;
            }

            @Override
            public boolean addAll(@NonNull Collection<? extends View> c) {
                return false;
            }

            @Override
            public boolean addAll(int index, @NonNull Collection<? extends View> c) {
                return false;
            }

            @Override
            public boolean removeAll(@NonNull Collection<?> c) {
                return false;
            }

            @Override
            public boolean retainAll(@NonNull Collection<?> c) {
                return false;
            }

            @Override
            public void clear() {

            }

            @Override
            public View get(int index) {
                return null;
            }

            @Override
            public View set(int index, View element) {
                return null;
            }

            @Override
            public void add(int index, View element) {

            }

            @Override
            public View remove(int index) {
                return null;
            }

            @Override
            public int indexOf(Object o) {
                return 0;
            }

            @Override
            public int lastIndexOf(Object o) {
                return 0;
            }

            @NonNull
            @Override
            public ListIterator<View> listIterator() {
                return null;
            }

            @NonNull
            @Override
            public ListIterator<View> listIterator(int index) {
                return null;
            }

            @NonNull
            @Override
            public List<View> subList(int fromIndex, int toIndex) {
                return null;
            }
        };
        View ts = mMenuView.findViewById(R.id.fragment_ts);
        View cx = mMenuView.findViewById(R.id.fragment_cx);
        pages.add(ts);
        pages.add(cx);

        List<View> viewList = new ArrayList<>();

        LayoutInflater inflater = LayoutInflater.from(context);
        View tabts = inflater.inflate(R.layout.fragment_ts, null);
        View tabcx = inflater.inflate(R.layout.fragment_cx, null);
        View tablc = inflater.inflate(R.layout.fragment_lc, null);
        viewList.add(tabts);
        viewList.add(tabcx);
        viewList.add(tablc);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);
    }



    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llts:
                tvts.setHintTextColor(Color.parseColor("#bc6ba6"));
                tvts.setTextColor(Color.parseColor("#bc6ba6"));
                tvcx.setHintTextColor(Color.parseColor("#999999"));
                tvcx.setTextColor(Color.parseColor("#000000"));
                tvlc.setHintTextColor(Color.parseColor("#999999"));
                tvlc.setTextColor(Color.parseColor("#000000"));
                tabts.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.llcx:
                tvts.setHintTextColor(Color.parseColor("#999999"));
                tvts.setTextColor(Color.parseColor("#000000"));
                tvcx.setHintTextColor(Color.parseColor("#bc6ba6"));
                tvcx.setTextColor(Color.parseColor("#bc6ba6"));
                tvlc.setHintTextColor(Color.parseColor("#999999"));
                tvlc.setTextColor(Color.parseColor("#000000"));
                tabcx.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.lllc:
                tvts.setHintTextColor(Color.parseColor("#999999"));
                tvts.setTextColor(Color.parseColor("#000000"));
                tvcx.setHintTextColor(Color.parseColor("#999999"));
                tvcx.setTextColor(Color.parseColor("#000000"));
                tvlc.setHintTextColor(Color.parseColor("#bc6ba6"));
                tvlc.setTextColor(Color.parseColor("#bc6ba6"));
                tablc.select();
                mvpbody.setCurrentItem(2);
                break;
        }
    }
}
