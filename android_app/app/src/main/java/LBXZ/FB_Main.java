package LBXZ;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import Common.Base;
import Common.GRZX_Main;
import Common.GRZX_WDFB;
import com.example.administrator.Public.R;
import LBCX.SY_Main;
import Common.XX_Main;
import Common.YHDL;

public class FB_Main extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_main);
        resetBottomMenu();
        ImageView ivsy_fb = (ImageView) findViewById(R.id.ivFB);
        ivsy_fb.setImageResource(R.drawable.dbcd_fb_active);
        findById();
    }

    private void findById() {
        ViewGroup vgxx = (ViewGroup) findViewById(R.id.llXX);
        ViewGroup vggrzx = (ViewGroup) findViewById(R.id.llGRZX);
        ViewGroup vgsy = (ViewGroup) findViewById(R.id.llSY);
        TextView vgwdfb = (TextView) findViewById(R.id.tvWDFB);
        ViewGroup vgfc = (ViewGroup) findViewById(R.id.llFC);
        ViewGroup vgeswp = (ViewGroup) findViewById(R.id.llESWP);
        ViewGroup vgcl = (ViewGroup) findViewById(R.id.llCL);
        ViewGroup vgcw = (ViewGroup) findViewById(R.id.llCW);
        ViewGroup vgshfw = (ViewGroup) findViewById(R.id.llSHFW);
        ViewGroup vgswfw = (ViewGroup) findViewById(R.id.llSWFW);
        ViewGroup vgzsjm = (ViewGroup) findViewById(R.id.llZSJM);
        ViewGroup vgpfcg = (ViewGroup) findViewById(R.id.llPFCG);
        ViewGroup vgjypx = (ViewGroup) findViewById(R.id.llJYPX);
        ViewGroup vgzxjc = (ViewGroup) findViewById(R.id.llZXJC);
        ViewGroup vgxxyl = (ViewGroup) findViewById(R.id.llXXYL);
        ViewGroup vglr = (ViewGroup) findViewById(R.id.llLR);
        ViewGroup vglyjd = (ViewGroup) findViewById(R.id.llLYJD);
        ViewGroup vgnlmy = (ViewGroup) findViewById(R.id.llNLMY);
        vgxx.setOnClickListener(this);
        vggrzx.setOnClickListener(this);
        vgsy.setOnClickListener(this);
        vgwdfb.setOnClickListener(this);
        vgfc.setOnClickListener(this);
        vgeswp.setOnClickListener(this);
        vgcl.setOnClickListener(this);
        vgcw.setOnClickListener(this);
        vgshfw.setOnClickListener(this);
        vgswfw.setOnClickListener(this);
        vgzsjm.setOnClickListener(this);
        vgpfcg.setOnClickListener(this);
        vgjypx.setOnClickListener(this);
        vgzxjc.setOnClickListener(this);
        vgxxyl.setOnClickListener(this);
        vglr.setOnClickListener(this);
        vglyjd.setOnClickListener(this);
        vgnlmy.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llSY:
                YMTZ("SY");
                break;
            case R.id.llFB:
                YMTZ("FB");
                break;
            case R.id.llXX:
                YMTZ("XX");
                break;
            case R.id.llGRZX:
                YMTZ("GRZX");
                break;
            case R.id.tvWDFB:
                if (YHM != "")
                    YMTZ("WDFB");
                else
                    YMTZ("YHDL");
                break;
            case R.id.llFC:
                YMTZ("FC");
                break;
            case R.id.llESWP:
                YMTZ("ESWP");
                break;
            case R.id.llCL:
                YMTZ("CL");
                break;
            case R.id.llCW:
                YMTZ("CW");
                break;
            case R.id.llSHFW:
                YMTZ("SHFW");
                break;
            case R.id.llSWFW:
                YMTZ("SWFW");
                break;
            case R.id.llZSJM:
                YMTZ("ZSJM");
                break;
            case R.id.llPFCG:
                YMTZ("PFCG");
                break;
            case R.id.llJYPX:
                YMTZ("JYPX");
                break;
            case R.id.llZXJC:
                YMTZ("ZXJC");
                break;
            case R.id.llXXYL:
                YMTZ("XXYL");
                break;
            case R.id.llLR:
                YMTZ("LR");
                break;
            case R.id.llLYJD:
                YMTZ("LYJD");
                break;
            case R.id.llNLMY:
                YMTZ("NLMY");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if(id == "SY") {
            Intent intent = new Intent(FB_Main.this, SY_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "GRZX") {
            Intent intent = new Intent(FB_Main.this, GRZX_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if(id == "XX") {
            Intent intent = new Intent(FB_Main.this, XX_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "YHDL") {
            Intent intent = new Intent(FB_Main.this, YHDL.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "WDFB") {
            Intent intent = new Intent(FB_Main.this, GRZX_WDFB.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FC") {
//            if(Base.YHM == null) {
//                Intent intent = new Intent(FB_Main.this, YHDL.class);
//                startActivity(intent);
//                finish();//关闭当前页面
//            }
//            else {
                Intent intent = new Intent(FB_Main.this, FB_FC.class);
                startActivity(intent);
                finish();//关闭当前页面
//            }
        }
        if (id == "ESWP") {
            Intent intent = new Intent(FB_Main.this, FB_ESWP.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "CL") {
            Intent intent = new Intent(FB_Main.this, FB_CL.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "CW") {
            Intent intent = new Intent(FB_Main.this, FB_CW.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "SHFW") {
            Intent intent = new Intent(FB_Main.this, FB_SHFW.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "SWFW") {
            Intent intent = new Intent(FB_Main.this, FB_SWFW.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "ZSJM") {
            Intent intent = new Intent(FB_Main.this, FB_ZSJM.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "PFCG") {
            Intent intent = new Intent(FB_Main.this, FB_PFCG.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "JYPX") {
            Intent intent = new Intent(FB_Main.this, FB_JYPX.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "ZXJC") {
            Intent intent = new Intent(FB_Main.this, FB_ZXJC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "XXYL") {
            Intent intent = new Intent(FB_Main.this, FB_XXYL.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "LR") {
            Intent intent = new Intent(FB_Main.this, FB_LR.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "LYJD") {
            Intent intent = new Intent(FB_Main.this, FB_LYJD.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "NLMY") {
            Intent intent = new Intent(FB_Main.this, FB_NLMY.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }
}
