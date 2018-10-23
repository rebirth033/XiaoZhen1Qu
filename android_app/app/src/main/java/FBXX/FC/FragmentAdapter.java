package FBXX.FC;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import java.util.List;

public class FragmentAdapter extends FragmentPagerAdapter {
    private List<Fragment> mFragmentPair;
    public FragmentAdapter(FragmentManager fm,List<Fragment> mFragmentPair) {
        super(fm); this.mFragmentPair = mFragmentPair;
    }
    @Override
    public Fragment getItem(int position) {
        return mFragmentPair.get(position);
    }
    @Override
    public int getCount() {
        return mFragmentPair.size();
    }
    @Override
    public CharSequence getPageTitle(int position) {
        return mFragmentPair.get(position).toString();
    }
}

