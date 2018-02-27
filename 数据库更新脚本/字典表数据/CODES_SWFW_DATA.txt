prompt Importing table codes_swfw...
set feedback off
set define off
insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (1, '工商注册类别', '内资公司注册', '1', 1, null, 211, 'LB=1', 'nei zi gong si zhu ce ', 'neizigongsizhuce', 'nzgszc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (2, '工商注册类别', '海外公司注册', '2', 2, null, 211, 'LB=2', 'hai wai gong si zhu ce ', 'haiwaigongsizhuce', 'hwgszc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (3, '工商注册类别', '外资公司注册', '3', 3, null, 211, 'LB=3', 'wai zi gong si zhu ce ', 'waizigongsizhuce', 'wzgszc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (4, '工商注册类别', '香港公司注册', '4', 4, null, 211, 'LB=4', 'xiang gang gong si zhu ce ', 'xiangganggongsizhuce', 'xggszc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (5, '工商注册类别', '专项审批', '5', 5, null, 211, 'LB=5', 'zhuan xiang shen pi ', 'zhuanxiangshenpi', 'zxsp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (6, '工商注册类别', '工商年检', '6', 6, null, 211, 'LB=6', 'gong shang nian jian ', 'gongshangnianjian', 'gsnj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (7, '工商注册类别', '验资开户', '7', 7, null, 211, 'LB=7', 'yan zi kai hu ', 'yanzikaihu', 'yzkh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (8, '工商注册类别', '资质认证', '8', 8, null, 211, 'LB=8', 'zi zhi ren zheng ', 'zizhirenzheng', 'zzrz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (9, '工商注册类别', '公司变更', '9', 9, null, 211, 'LB=9', 'gong si bian geng ', 'gongsibiangeng', 'gsbg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (10, '工商注册类别', '公司注销', '10', 10, null, 211, 'LB=10', 'gong si zhu xiao ', 'gongsizhuxiao', 'gszx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (11, '工商注册类别', '一般纳税人申请', '11', 11, null, 211, 'LB=11', 'yi ban na shui ren shen qing ', 'yibannashuirenshenqing', 'ybnsrsq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (12, '商标专利类别', '商标服务', '1', 1, null, 212, 'LB=12', 'shang biao fu wu ', 'shangbiaofuwu', 'sbfw');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (13, '商标专利类别', '专利服务', '2', 2, null, 212, 'LB=13', 'zhuan li fu wu ', 'zhuanlifuwu', 'zlfw');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (14, '商标专利类别', '版权服务', '3', 3, null, 212, 'LB=14', 'ban quan fu wu ', 'banquanfuwu', 'bqfw');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (15, '商标服务', '商标变更', '1', 1, 12, 212, 'LB=12&XL=15', 'shang biao bian geng ', 'shangbiaobiangeng', 'sbbg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (16, '商标服务', '商标许可', '2', 2, 12, 212, 'LB=12&XL=16', 'shang biao xu ke ', 'shangbiaoxuke', 'sbxk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (17, '商标服务', '商标案件', '3', 3, 12, 212, 'LB=12&XL=17', 'shang biao an jian ', 'shangbiaoanjian', 'sbaj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (18, '商标服务', '商标补正', '4', 4, 12, 212, 'LB=12&XL=18', 'shang biao bu zheng ', 'shangbiaobuzheng', 'sbbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (19, '商标服务', '商标续展', '5', 5, 12, 212, 'LB=12&XL=19', 'shang biao xu zhan ', 'shangbiaoxuzhan', 'sbxz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (20, '商标服务', '商标转让', '6', 6, 12, 212, 'LB=12&XL=20', 'shang biao zhuan rang ', 'shangbiaozhuanrang', 'sbzr');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (21, '商标服务', '商标注册', '7', 7, 12, 212, 'LB=12&XL=21', 'shang biao zhu ce ', 'shangbiaozhuce', 'sbzc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (22, '专利服务', '专利申请', '1', 1, 13, 212, 'LB=13&XL=22', 'zhuan li shen qing ', 'zhuanlishenqing', 'zlsq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (23, '专利服务', '专利变更', '2', 2, 13, 212, 'LB=13&XL=23', 'zhuan li bian geng ', 'zhuanlibiangeng', 'zlbg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (24, '专利服务', '专利转让', '3', 3, 13, 212, 'LB=13&XL=24', 'zhuan li zhuan rang ', 'zhuanlizhuanrang', 'zlzr');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (25, '专利服务', '专利实施许可', '4', 4, 13, 212, 'LB=13&XL=25', 'zhuan li shi shi xu ke ', 'zhuanlishishixuke', 'zlssxk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (26, '专利服务', '专利诉讼', '5', 5, 13, 212, 'LB=13&XL=26', 'zhuan li su song ', 'zhuanlisusong', 'zlss');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (27, '版权服务', '版权登记', '1', 1, 14, 212, 'LB=14&XL=27', 'ban quan deng ji ', 'banquandengji', 'bqdj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (28, '版权服务', '版权转让', '3', 3, 14, 212, 'LB=14&XL=28', 'ban quan zhuan rang ', 'banquanzhuanrang', 'bqzr');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (29, '版权服务', '版权许可', '4', 4, 14, 212, 'LB=14&XL=29', 'ban quan xu ke ', 'banquanxuke', 'bqxk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (30, '版权服务', '版权纠纷', '5', 5, 14, 212, 'LB=14&XL=30', 'ban quan jiu fen ', 'banquanjiufen', 'bqjf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (31, '版权服务', '版权变更', '2', 2, 14, 212, 'LB=14&XL=31', 'ban quan bian geng ', 'banquanbiangeng', 'bqbg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (32, '法律咨询类别', '知识产权', '1', 1, null, 232, 'LB=32', 'zhi shi chan quan ', 'zhishichanquan', 'zscq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (33, '法律咨询类别', '房产纠纷', '2', 2, null, 232, 'LB=33', 'fang chan jiu fen ', 'fangchanjiufen', 'fcjf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (34, '法律咨询类别', '劳动争议', '3', 3, null, 232, 'LB=34', 'lao dong zheng yi ', 'laodongzhengyi', 'ldzy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (35, '法律咨询类别', '商业纠纷', '4', 4, null, 232, 'LB=35', 'shang ye jiu fen ', 'shangyejiufen', 'syjf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (36, '法律咨询类别', '合同纠纷', '5', 5, null, 232, 'LB=36', 'he tong jiu fen ', 'hetongjiufen', 'htjf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (37, '法律咨询类别', '建筑工程', '6', 6, null, 232, 'LB=37', 'jian zhu gong cheng ', 'jianzhugongcheng', 'jzgc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (38, '法律咨询类别', '债务纠纷', '7', 7, null, 232, 'LB=38', 'zhai wu jiu fen ', 'zhaiwujiufen', 'zwjf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (39, '法律咨询类别', '刑事辩护/诉讼', '8', 8, null, 232, 'LB=39', 'xing shi bian hu /su song ', 'xingshibianhu/susong', 'xsbh/ss');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (40, '法律咨询类别', '公司法务', '9', 9, null, 232, 'LB=40', 'gong si fa wu ', 'gongsifawu', 'gsfw');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (41, '法律咨询类别', '法律援助', '10', 10, null, 232, 'LB=41', 'fa lv yuan zhu ', 'falvyuanzhu', 'flyz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (42, '法律咨询类别', '婚姻家庭', '11', 11, null, 232, 'LB=42', 'hun yin jia ting ', 'hunyinjiating', 'hyjt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (43, '法律咨询类别', '征地补偿', '12', 12, null, 232, 'LB=43', 'zheng di bu chang ', 'zhengdibuchang', 'zdbc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (44, '法律咨询类别', '交通事故', '13', 13, null, 232, 'LB=44', 'jiao tong shi gu ', 'jiaotongshigu', 'jtsg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (45, '法律咨询类别', '医疗事故', '14', 14, null, 232, 'LB=45', 'yi liao shi gu ', 'yiliaoshigu', 'ylsg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (46, '法律咨询类别', '涉外法律', '15', 15, null, 232, 'LB=46', 'she wai fa lv ', 'shewaifalv', 'swfl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (47, '财务会计/评估类别', '代理记账', '1', 1, null, 236, 'LB=47', 'dai li ji zhang ', 'dailijizhang', 'dljz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (48, '财务会计/评估类别', '验资', '2', 2, null, 236, 'LB=48', 'yan zi ', 'yanzi', 'yz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (49, '财务会计/评估类别', '财务审计', '3', 3, null, 236, 'LB=49', 'cai wu shen ji ', 'caiwushenji', 'cwsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (50, '财务会计/评估类别', '资产评估', '4', 4, null, 236, 'LB=50', 'zi chan ping gu ', 'zichanpinggu', 'zcpg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (51, '财务会计/评估类别', '税务咨询', '5', 5, null, 236, 'LB=51', 'shui wu zi xun ', 'shuiwuzixun', 'swzx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (52, '财务会计/评估类别', '工程造价', '6', 6, null, 236, 'LB=52', 'gong cheng zao jia ', 'gongchengzaojia', 'gczj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (53, '财务会计/评估类别', '财税疑难', '7', 7, null, 236, 'LB=53', 'cai shui yi nan ', 'caishuiyinan', 'csyn');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (54, '财务会计/评估类别', '纳税申报', '8', 8, null, 236, 'LB=54', 'na shui shen bao ', 'nashuishenbao', 'nssb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (55, '保险服务类别', '意外险', '1', 1, null, 237, 'LB=55', 'yi wai xian ', 'yiwaixian', 'ywx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (56, '保险服务类别', '旅游保险', '2', 2, null, 237, 'LB=56', 'lv you bao xian ', 'lvyoubaoxian', 'lybx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (57, '保险服务类别', '签证保险', '3', 3, null, 237, 'LB=57', 'qian zheng bao xian ', 'qianzhengbaoxian', 'qzbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (58, '保险服务类别', '健康险', '4', 4, null, 237, 'LB=58', 'jian kang xian ', 'jiankangxian', 'jkx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (59, '保险服务类别', '人寿险', '5', 5, null, 237, 'LB=59', 'ren shou xian ', 'renshouxian', 'rsx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (60, '保险服务类别', '少儿保险', '6', 6, null, 237, 'LB=60', 'shao dong bao xian ', 'shaodongbaoxian', 'sdbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (61, '保险服务类别', '商业养老险', '7', 7, null, 237, 'LB=61', 'shang ye yang lao xian ', 'shangyeyanglaoxian', 'syylx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (62, '保险服务类别', '投资型保险', '8', 8, null, 237, 'LB=62', 'tou zi xing bao xian ', 'touzixingbaoxian', 'tzxbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (63, '保险服务类别', '家财险', '9', 9, null, 237, 'LB=63', 'jia cai xian ', 'jiacaixian', 'jcx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (64, '保险服务类别', '企业财产险', '10', 10, null, 237, 'LB=64', 'qi ye cai chan xian ', 'qiyecaichanxian', 'qyccx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (65, '保险服务类别', '汽车保险', '11', 11, null, 237, 'LB=65', 'qi che bao xian ', 'qichebaoxian', 'qcbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (66, '意外险', '综合意外险', '1', 1, 55, 237, 'LB=55&XL=66', 'zong he yi wai xian ', 'zongheyiwaixian', 'zhywx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (67, '意外险', '人身意外险', '2', 2, 55, 237, 'LB=55&XL=67', 'ren shen yi wai xian ', 'renshenyiwaixian', 'rsywx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (68, '意外险', '交通意外险', '3', 3, 55, 237, 'LB=55&XL=68', 'jiao tong yi wai xian ', 'jiaotongyiwaixian', 'jtywx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (69, '意外险', '航空意外险', '4', 4, 55, 237, 'LB=55&XL=69', 'hang kong yi wai xian ', 'hangkongyiwaixian', 'hkywx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (70, '旅游保险', '国内旅游保险', '1', 1, 56, 237, 'LB=56&XL=70', 'guo nei lv you bao xian ', 'guoneilvyoubaoxian', 'gnlybx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (71, '旅游保险', '境外旅游保险', '2', 2, 56, 237, 'LB=56&XL=71', 'jing wai lv you bao xian ', 'jingwailvyoubaoxian', 'jwlybx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (72, '健康险', '重大疾病保险', '1', 1, 58, 237, 'LB=58&XL=72', 'zhong da ji bing bao xian ', 'zhongdajibingbaoxian', 'zdjbbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (73, '健康险', '商业医疗保险 ', '2', 2, 58, 237, 'LB=58&XL=73', 'shang ye yi liao bao xian  ', 'shangyeyiliaobaoxian', 'syylbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (74, '健康险', '特定疾病保险', '3', 3, 58, 237, 'LB=58&XL=74', 'te ding ji bing bao xian ', 'tedingjibingbaoxian', 'tdjbbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (75, '健康险', '女性疾病保险', '4', 4, 58, 237, 'LB=58&XL=75', 'nv xing ji bing bao xian ', 'nvxingjibingbaoxian', 'nxjbbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (76, '人寿险', '定期寿险', '1', 1, 59, 237, 'LB=59&XL=76', 'ding qi shou xian ', 'dingqishouxian', 'dqsx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (77, '人寿险', '终身寿险', '2', 2, 59, 237, 'LB=59&XL=77', 'zhong shen shou xian ', 'zhongshenshouxian', 'zssx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (78, '人寿险', '两全保险', '3', 3, 59, 237, 'LB=59&XL=78', 'liang quan bao xian ', 'liangquanbaoxian', 'lqbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (79, '人寿险', '年金保险', '4', 4, 59, 237, 'LB=59&XL=79', 'nian jin bao xian ', 'nianjinbaoxian', 'njbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (80, '少儿保险', '少儿意外伤害', '1', 1, 60, 237, 'LB=60&XL=80', 'shao dong yi wai shang hai ', 'shaodongyiwaishanghai', 'sdywsh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (81, '少儿保险', '少儿健康医疗', '2', 2, 60, 237, 'LB=60&XL=81', 'shao dong jian kang yi liao ', 'shaodongjiankangyiliao', 'sdjkyl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (82, '少儿保险', '少儿教育储蓄', '3', 3, 60, 237, 'LB=60&XL=82', 'shao dong jiao yu chu xu ', 'shaodongjiaoyuchuxu', 'sdjycx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (83, '商业养老险', '分红型', '1', 1, 61, 237, 'LB=61&XL=83', 'fen hong xing ', 'fenhongxing', 'fhx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (84, '商业养老险', '两全型', '2', 2, 61, 237, 'LB=61&XL=84', 'liang quan xing ', 'liangquanxing', 'lqx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (85, '商业养老险', '万能型', '3', 3, 61, 237, 'LB=61&XL=85', 'wan neng xing ', 'wannengxing', 'wnx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (86, '投资型保险', '分红险', '1', 1, 62, 237, 'LB=62&XL=86', 'fen hong xian ', 'fenhongxian', 'fhx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (87, '投资型保险', '万能险', '2', 2, 62, 237, 'LB=62&XL=87', 'wan neng xian ', 'wannengxian', 'wnx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (88, '投资型保险', '投连险', '3', 3, 62, 237, 'LB=62&XL=88', 'tou lian xian ', 'toulianxian', 'tlx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (89, '投资型保险', '教育金', '4', 4, 62, 237, 'LB=62&XL=89', 'jiao yu jin ', 'jiaoyujin', 'jyj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (90, '家财险', '自住型', '1', 1, 63, 237, 'LB=63&XL=90', 'zi zhu xing ', 'zizhuxing', 'zzx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (91, '家财险', '租房型', '2', 2, 63, 237, 'LB=63&XL=91', 'zu fang xing ', 'zufangxing', 'zfx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (92, '家财险', '出租型', '3', 3, 63, 237, 'LB=63&XL=92', 'chu zu xing ', 'chuzuxing', 'czx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (93, '家财险', '网店型', '4', 4, 63, 237, 'LB=63&XL=93', 'wang dian xing ', 'wangdianxing', 'wdx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (94, '企业财产险', '财产综合险', '1', 1, 64, 237, 'LB=64&XL=94', 'cai chan zong he xian ', 'caichanzonghexian', 'cczhx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (95, '企业财产险', '财产基本险', '2', 2, 64, 237, 'LB=64&XL=95', 'cai chan ji ben xian ', 'caichanjibenxian', 'ccjbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (96, '企业财产险', '财产一切险', '3', 3, 64, 237, 'LB=64&XL=96', 'cai chan yi qie xian ', 'caichanyiqiexian', 'ccyqx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (97, '企业财产险', '计算机保险', '4', 4, 64, 237, 'LB=64&XL=97', 'ji suan ji bao xian ', 'jisuanjibaoxian', 'jsjbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (98, '企业财产险', '利润损失险', '5', 5, 64, 237, 'LB=64&XL=98', 'li run sun shi xian ', 'lirunsunshixian', 'lrssx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (99, '企业财产险', '机器损坏险', '6', 6, 64, 237, 'LB=64&XL=99', 'ji qi sun huai xian ', 'jiqisunhuaixian', 'jqshx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (100, '投资担保类别', '担保', '1', 1, null, 238, 'LB=100', 'dan bao ', 'danbao', 'db');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (101, '投资担保类别', '投资', '2', 2, null, 238, 'LB=101', 'tou zi ', 'touzi', 'tz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (102, '投资担保类别', '典当行', '3', 3, null, 238, 'LB=102', 'dian dang xing ', 'diandangxing', 'ddx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (103, '投资担保类别', '贷款', '4', 4, null, 238, 'LB=103', 'dai kuan ', 'daikuan', 'dk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (104, '投资担保类别', '银行直投', '5', 5, null, 238, 'LB=104', 'yin xing zhi tou ', 'yinxingzhitou', 'yxzt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (105, '担保', '无抵押', '1', 1, 100, 238, 'LB=100&XL=105', 'wu di ya ', 'wudiya', 'wdy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (106, '担保', '房产抵押', '2', 2, 100, 238, 'LB=100&XL=106', 'fang chan di ya ', 'fangchandiya', 'fcdy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (107, '担保', '汽车抵押', '3', 3, 100, 238, 'LB=100&XL=107', 'qi che di ya ', 'qichediya', 'qcdy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (108, '担保', '证券质押', '4', 4, 100, 238, 'LB=100&XL=108', 'zheng quan zhi ya ', 'zhengquanzhiya', 'zqzy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (109, '典当行', '房产抵押', '1', 1, 102, 238, 'LB=102&XL=109', 'fang chan di ya ', 'fangchandiya', 'fcdy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (110, '典当行', '汽车质押', '2', 2, 102, 238, 'LB=102&XL=110', 'qi che zhi ya ', 'qichezhiya', 'qczy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (111, '典当行', '证券质押', '3', 3, 102, 238, 'LB=102&XL=111', 'zheng quan zhi ya ', 'zhengquanzhiya', 'zqzy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (112, '典当行', '股票质押', '4', 4, 102, 238, 'LB=102&XL=112', 'gu piao zhi ya ', 'gupiaozhiya', 'gpzy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (113, '典当行', '财产质押', '5', 5, 102, 238, 'LB=102&XL=113', 'cai chan zhi ya ', 'caichanzhiya', 'cczy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (114, '贷款', '个人信贷', '1', 1, 103, 238, 'LB=103&XL=114', 'ge ren xin dai ', 'gerenxindai', 'grxd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (115, '贷款', '企业信贷', '2', 2, 103, 238, 'LB=103&XL=115', 'qi ye xin dai ', 'qiyexindai', 'qyxd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (116, '贷款', '抵押贷款', '3', 3, 103, 238, 'LB=103&XL=116', 'di ya dai kuan ', 'diyadaikuan', 'dydk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (117, '贷款', '质押贷款', '4', 4, 103, 238, 'LB=103&XL=117', 'zhi ya dai kuan ', 'zhiyadaikuan', 'zydk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (118, '印刷包装类别', '包装', '1', 1, null, 217, 'LB=118', 'bao zhuang ', 'baozhuang', 'bz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (119, '印刷包装类别', '纸类印刷', '2', 2, null, 217, 'LB=119', 'zhi lei yin shua ', 'zhileiyinshua', 'zlys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (120, '印刷包装类别', '防伪印刷', '3', 3, null, 217, 'LB=120', 'fang wei yin shua ', 'fangweiyinshua', 'fwys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (121, '印刷包装类别', '名片印刷', '4', 4, null, 217, 'LB=121', 'ming pian yin shua ', 'mingpianyinshua', 'mpys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (122, '印刷包装类别', '书刊印刷', '5', 5, null, 217, 'LB=122', 'shu kan yin shua ', 'shukanyinshua', 'skys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (123, '印刷包装类别', '不干胶印刷', '6', 6, null, 217, 'LB=123', 'bu gan jiao yin shua ', 'buganjiaoyinshua', 'bgjys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (124, '印刷包装类别', '服装印花', '7', 7, null, 217, 'LB=124', 'fu zhuang yin hua ', 'fuzhuangyinhua', 'fzyh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (125, '印刷包装类别', '仪器面板印刷', '8', 8, null, 217, 'LB=125', 'yi qi mian ban yin shua ', 'yiqimianbanyinshua', 'yqmbys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (126, '印刷包装类别', '办公礼品印刷', '9', 9, null, 217, 'LB=126', 'ban gong li pin yin shua ', 'bangonglipinyinshua', 'bglpys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (127, '印刷包装类别', '宣传资料印刷', '10', 10, null, 217, 'LB=127', 'xuan chuan zi liao yin shua ', 'xuanchuanziliaoyinshua', 'xczlys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (128, '印刷包装类别', '春联', '11', 11, null, 217, 'LB=128', 'chun lian ', 'chunlian', 'cl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (129, '材质', '塑料', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (130, '材质', '纸类', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (131, '材质', '布类', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (132, '材质', '金属', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (133, '材质', '木质', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (134, '材质', '玻璃', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (135, '用途', '礼品包装', '1', 1, null, 217, 'YT', 'li pin bao zhuang ', 'lipinbaozhuang', 'lpbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (136, '用途', '食品包装', '2', 2, null, 217, 'YT', 'shi pin bao zhuang ', 'shipinbaozhuang', 'spbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (137, '用途', '饰品包装', '3', 3, null, 217, 'YT', 'shi pin bao zhuang ', 'shipinbaozhuang', 'spbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (138, '用途', '服装包装', '4', 4, null, 217, 'YT', 'fu zhuang bao zhuang ', 'fuzhuangbaozhuang', 'fzbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (139, '用途', '玩具包装', '5', 5, null, 217, 'YT', 'wan ju bao zhuang ', 'wanjubaozhuang', 'wjbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (140, '用途', '数码/电子包装', '6', 6, null, 217, 'YT', 'shu ma /dian zi bao zhuang ', 'shuma/dianzibaozhuang', 'sm/dzbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (141, '用途', '化妆品包装', '7', 7, null, 217, 'YT', 'hua zhuang pin bao zhuang ', 'huazhuangpinbaozhuang', 'hzpbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (142, '用途', '药品包装', '8', 8, null, 217, 'YT', 'yao pin bao zhuang ', 'yaopinbaozhuang', 'ypbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (143, '用途', '仪器包装', '9', 9, null, 217, 'YT', 'yi qi bao zhuang ', 'yiqibaozhuang', 'yqbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (144, '用途', '香烟包装', '10', 10, null, 217, 'YT', 'xiang yan bao zhuang ', 'xiangyanbaozhuang', 'xybz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (145, '用途', '五金包装', '11', 11, null, 217, 'YT', 'wu jin bao zhuang ', 'wujinbaozhuang', 'wjbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (146, '用途', '酒水包装', '12', 12, null, 217, 'YT', 'jiu shui bao zhuang ', 'jiushuibaozhuang', 'jsbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (147, '用途', '茶叶包装', '13', 13, null, 217, 'YT', 'cha ye bao zhuang ', 'chayebaozhuang', 'cybz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (148, '包装容器', '包装盒/包装箱', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (149, '包装容器', '包装袋', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (150, '包装容器', '桶', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (151, '包装容器', '杯', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (152, '包装容器', '瓶/罐', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (153, '包装容器', '软管', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (154, '纸类印刷', '票据印刷', '1', 1, 119, 217, 'LB=119&XL=154', 'piao ju yin shua ', 'piaojuyinshua', 'pjys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (155, '纸类印刷', '台历制作', '2', 2, 119, 217, 'LB=119&XL=155', 'tai li zhi zuo ', 'tailizhizuo', 'tlzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (156, '宣传资料印刷', '手提袋', '1', 1, 127, 217, 'LB=127&XL=156', 'shou ti dai ', 'shoutidai', 'std');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (157, '宣传资料印刷', '封套', '2', 2, 127, 217, 'LB=127&XL=157', 'feng tao ', 'fengtao', 'ft');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (158, '宣传资料印刷', '优惠券/门票', '3', 3, 127, 217, 'LB=127&XL=158', 'you hui quan /men piao ', 'youhuiquan/menpiao', 'yhq/mp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (159, '宣传资料印刷', '单页/折页', '4', 4, 127, 217, 'LB=127&XL=159', 'dan ye /zhe ye ', 'danye/zheye', 'dy/zy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (160, '宣传资料印刷', '海报', '5', 5, 127, 217, 'LB=127&XL=160', 'hai bao ', 'haibao', 'hb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (161, '宣传资料印刷', '工程图/效果图', '6', 6, 127, 217, 'LB=127&XL=161', 'gong cheng tu /xiao guo tu ', 'gongchengtu/xiaoguotu', 'gct/xgt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (162, '宣传资料印刷', '画册', '7', 7, 127, 217, 'LB=127&XL=162', 'hua ce ', 'huace', 'hc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (163, '工艺', '无碳复写', '1', 1, null, 217, 'XL', 'wu tan fu xie ', 'wutanfuxie', 'wtfx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (164, '工艺', '丝网印刷', '2', 2, null, 217, 'XL', 'si wang yin shua ', 'siwangyinshua', 'swys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (165, '工艺', '数码印刷', '3', 3, null, 217, 'XL', 'shu ma yin shua ', 'shumayinshua', 'smys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (166, '工艺', '彩印', '4', 4, null, 217, 'XL', 'cai yin ', 'caiyin', 'cy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (167, '工艺', '胶印', '5', 5, null, 217, 'XL', 'jiao yin ', 'jiaoyin', 'jy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (168, '工艺', '热转印', '6', 6, null, 217, 'XL', 're zhuan yin ', 'rezhuanyin', 'rzy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (169, '工艺', '水转印', '7', 7, null, 217, 'XL', 'shui zhuan yin ', 'shuizhuanyin', 'szy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (170, '工艺', '凹印', '8', 8, null, 217, 'XL', 'ao yin ', 'aoyin', 'ay');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (171, '工艺', '柔印', '9', 9, null, 217, 'XL', 'rou yin ', 'rouyin', 'ry');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (172, '工艺', '移印', '10', 10, null, 217, 'XL', 'yi yin ', 'yiyin', 'yy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (173, '工艺', '立体印刷', '11', 11, null, 217, 'XL', 'li ti yin shua ', 'litiyinshua', 'ltys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (174, '喷绘招牌类别', '灯箱/招牌', '1', 1, null, 218, 'LB=174', 'deng xiang /zhao pai ', 'dengxiang/zhaopai', 'dx/zp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (175, '喷绘招牌类别', '亮化工程', '2', 2, null, 218, 'LB=175', 'liang hua gong cheng ', 'lianghuagongcheng', 'lhgc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (176, '喷绘招牌类别', '背景/形象墙', '3', 3, null, 218, 'LB=176', 'bei jing /xing xiang qiang ', 'beijing/xingxiangqiang', 'bj/xxq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (177, '喷绘招牌类别', '展架制作', '4', 4, null, 218, 'LB=177', 'zhan jia zhi zuo ', 'zhanjiazhizuo', 'zjzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (178, '喷绘招牌类别', '户外广告', '5', 5, null, 218, 'LB=178', 'hu wai guang gao ', 'huwaiguanggao', 'hwgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (179, '喷绘招牌类别', '标牌', '6', 6, null, 218, 'LB=179', 'biao pai ', 'biaopai', 'bp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (180, '喷绘招牌类别', 'LED显示屏', '7', 7, null, 218, 'LB=180', 'LEDxian shi ping ', 'LEDxianshiping', 'Lsp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (181, '喷绘招牌类别', '条幅/锦旗/奖牌', '8', 8, null, 218, 'LB=181', 'tiao fu /jin qi /jiang pai ', 'tiaofu/jinqi/jiangpai', 'tf/jq/jp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (182, '灯箱/招牌材质', '钛金', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (183, '灯箱/招牌材质', '不锈钢', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (184, '灯箱/招牌材质', '铜', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (185, '灯箱/招牌材质', '有色亚克力', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (186, '灯箱/招牌材质', '树脂/塑料', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (187, '灯箱/招牌材质', '透明亚克力/水晶', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (188, '灯箱/招牌材质', '铁', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (189, '灯箱/招牌材质', 'PVC', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (190, '灯箱/招牌材质', '铝', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (191, '灯箱/招牌材质', '金箔', '10', 10, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (192, '灯箱/招牌材质', '木制', '11', 11, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (193, '灯箱/招牌工艺', '喷绘', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (194, '灯箱/招牌工艺', '吸塑', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (195, '灯箱/招牌工艺', '拉丝', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (196, '灯箱/招牌工艺', '丝印', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (197, '灯箱/招牌工艺', '冲孔', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (198, '灯箱/招牌工艺', 'LED', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (199, '灯箱/招牌工艺', '烤漆', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (200, '灯箱/招牌', '灯箱', '1', 1, 174, 218, 'LB=174&XL=200', 'deng xiang ', 'dengxiang', 'dx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (201, '灯箱/招牌', '广告字', '2', 2, 174, 218, 'LB=174&XL=201', 'guang gao zi ', 'guanggaozi', 'ggz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (202, '灯箱/招牌', '广告牌', '3', 3, 174, 218, 'LB=174&XL=202', 'guang gao pai ', 'guanggaopai', 'ggp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (203, '亮化工程', '楼体亮化', '1', 1, 175, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (204, '亮化工程', '景观照明', '2', 2, 175, 218, 'LB=175&XL=204', 'jing guan zhao ming ', 'jingguanzhaoming', 'jgzm');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (205, '亮化工程', '城市亮化', '3', 3, 175, 218, 'LB=175&XL=205', 'cheng shi liang hua ', 'chengshilianghua', 'cslh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (206, '亮化工程', '霓虹灯工程', '4', 4, 175, 218, 'LB=175&XL=206', 'ni hong deng gong cheng ', 'nihongdenggongcheng', 'nhdgc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (207, '亮化工程', '场馆照明', '5', 5, 175, 218, 'LB=175&XL=207', 'chang guan zhao ming ', 'changguanzhaoming', 'cgzm');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (208, '背景/形象墙', '会议背景', '1', 1, 176, 218, 'LB=176&XL=208', 'hui yi bei jing ', 'huiyibeijing', 'hybj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (209, '背景/形象墙', '形象墙', '2', 2, 176, 218, 'LB=176&XL=209', 'xing xiang qiang ', 'xingxiangqiang', 'xxq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (210, '背景/形象墙', '舞台背景', '3', 3, 176, 218, 'LB=176&XL=210', 'wu tai bei jing ', 'wutaibeijing', 'wtbj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (211, '展架制作', '拉网展架', '1', 1, 177, 218, 'LB=177&XL=211', 'la wang zhan jia ', 'lawangzhanjia', 'lwzj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (212, '展架制作', '易拉宝', '2', 2, 177, 218, 'LB=177&XL=212', 'yi la bao ', 'yilabao', 'ylb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (213, '展架制作', 'X展架', '3', 3, 177, 218, 'LB=177&XL=213', 'Xzhan jia ', 'Xzhanjia', 'Xj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (214, '展架制作', '促销台', '4', 4, 177, 218, 'LB=177&XL=214', 'cu xiao tai ', 'cuxiaotai', 'cxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (215, '展架制作', '注水旗杆', '5', 5, 177, 218, 'LB=177&XL=215', 'zhu shui qi gan ', 'zhushuiqigan', 'zsqg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (216, '展架制作', '挂画架', '6', 6, 177, 218, 'LB=177&XL=216', 'gua hua jia ', 'guahuajia', 'ghj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (217, '展架制作', '人像立牌', '7', 7, 177, 218, 'LB=177&XL=217', 'ren xiang li pai ', 'renxianglipai', 'rxlp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (218, '展架制作', '海报架', '8', 8, 177, 218, 'LB=177&XL=218', 'hai bao jia ', 'haibaojia', 'hbj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (219, '展架制作', 'L展架', '9', 9, 177, 218, 'LB=177&XL=219', 'Lzhan jia ', 'Lzhanjia', 'Lj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (220, '展架制作', '资料架', '10', 10, 177, 218, 'LB=177&XL=220', 'zi liao jia ', 'ziliaojia', 'zlj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (221, '展架制作', '广告帐篷', '11', 11, 177, 218, 'LB=177&XL=221', 'guang gao zhang peng ', 'guanggaozhangpeng', 'ggzp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (222, '户外广告', '车体广告', '1', 1, 178, 218, 'LB=178&XL=222', 'che ti guang gao ', 'chetiguanggao', 'ctgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (223, '户外广告', '玻璃贴', '2', 2, 178, 218, 'LB=178&XL=223', 'bo li tie ', 'bolitie', 'blt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (224, '户外广告', '工程围挡', '3', 3, 178, 218, 'LB=178&XL=224', 'gong cheng wei dang ', 'gongchengweidang', 'gcwd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (225, '户外广告', '楼顶广告牌', '4', 4, 178, 218, 'LB=178&XL=225', 'lou ding guang gao pai ', 'loudingguanggaopai', 'ldggp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (226, '户外广告', '楼体广告', '5', 5, 178, 218, 'LB=178&XL=226', 'lou ti guang gao ', 'loutiguanggao', 'ltgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (227, '户外广告', '升空气球', '6', 6, 178, 218, 'LB=178&XL=227', 'sheng kong qi qiu ', 'shengkongqiqiu', 'skqq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (228, '户外广告', '墙体广告', '7', 7, 178, 218, 'LB=178&XL=228', 'qiang ti guang gao ', 'qiangtiguanggao', 'qtgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (229, '标牌用途', '机场车站', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (230, '标牌用途', '体育场馆', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (231, '标牌用途', '文化会展', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (232, '标牌用途', '写字楼', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (233, '标牌用途', '医院', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (234, '标牌用途', '工业园区', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (235, '标牌用途', '学校', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (236, '标牌用途', '公园景区', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (237, '标牌用途', '停车场', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (238, '标牌用途', '城市街区', '10', 10, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (239, '标牌用途', '商场', '11', 11, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (240, '标牌用途', '宾馆酒店', '12', 12, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (241, '标牌用途', '地铁', '13', 13, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (242, '标牌功能', '立式导向牌', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (243, '标牌功能', '吊式导向牌', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (244, '标牌功能', '大堂水牌', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (245, '标牌功能', '桌牌', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (246, '标牌功能', '楼层号牌', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (247, '标牌功能', '门牌', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (248, '标牌功能', '宣传栏', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (249, '标牌功能', '公司铭牌', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (250, '标牌功能', '授权牌', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (251, '标牌功能', '胸牌/徽章', '10', 10, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (252, '标牌功能', '安全标识', '11', 11, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (253, '标牌功能', '夜光标牌', '12', 12, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (254, '标牌材质', '不锈钢', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (255, '标牌材质', '钛金', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (256, '标牌材质', '亚克力', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (257, '标牌材质', '电光板', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (258, '标牌材质', '铝制', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (259, '标牌材质', '铜', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (260, '标牌材质', '塑料', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (261, '标牌材质', '锌合金', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (262, 'LED显示屏', '户外单色显示屏', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (263, 'LED显示屏', '室内单色显示屏', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (264, 'LED显示屏', '户外双色显示屏', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (265, 'LED显示屏', '室内双色显示屏', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (266, 'LED显示屏', '户外全彩显示屏', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (267, 'LED显示屏', '室内全彩显示屏', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (268, '条幅/锦旗/奖牌', '条幅', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (269, '条幅/锦旗/奖牌', '锦旗', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (270, '条幅/锦旗/奖牌', '奖牌', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (271, '条幅/锦旗/奖牌', '奖杯', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (272, '条幅/锦旗/奖牌', '奖章', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (273, '是否发光', '是', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (274, '是否发光', '否', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (275, '设计策划类别', '视频制作', '1', 1, null, 219, 'LB=275', 'shi pin zhi zuo ', 'shipinzhizuo', 'spzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (276, '设计策划类别', '广告设计', '2', 2, null, 219, 'LB=276', 'guang gao she ji ', 'guanggaosheji', 'ggsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (277, '设计策划类别', '平面设计', '3', 3, null, 219, 'LB=277', 'ping mian she ji ', 'pingmiansheji', 'pmsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (278, '设计策划类别', '名片设计', '4', 4, null, 219, 'LB=278', 'ming pian she ji ', 'mingpiansheji', 'mpsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (279, '设计策划类别', '品牌策划推广', '5', 5, null, 219, 'LB=279', 'pin pai ce hua tui guang ', 'pinpaicehuatuiguang', 'ppchtg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (280, '设计策划类别', '工业设计', '6', 6, null, 219, 'LB=280', 'gong ye she ji ', 'gongyesheji', 'gysj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (281, '设计策划类别', 'SI店面设计', '7', 7, null, 219, 'LB=281', 'SIdian mian she ji ', 'SIdianmiansheji', 'Smsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (282, '设计策划类别', '装潢设计', '8', 8, null, 219, 'LB=282', 'zhuang huang she ji ', 'zhuanghuangsheji', 'zhsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (283, '设计策划类别', 'LOGO设计/VI设计', '9', 9, null, 219, 'LB=283', 'LOGOshe ji /VIshe ji ', 'LOGOsheji/VIsheji', 'Lj/Vj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (284, '设计策划类别', '建筑设计', '10', 10, null, 219, 'LB=284', 'jian zhu she ji ', 'jianzhusheji', 'jzsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (285, '设计策划类别', '景观设计', '11', 11, null, 219, 'LB=285', 'jing guan she ji ', 'jingguansheji', 'jgsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (286, '设计策划类别', '服装设计', '12', 12, null, 219, 'LB=286', 'fu zhuang she ji ', 'fuzhuangsheji', 'fzsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (287, '设计策划类别', '签名设计', '13', 13, null, 219, 'LB=287', 'qian ming she ji ', 'qianmingsheji', 'qmsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (288, '设计策划类别', '动漫设计', '14', 14, null, 219, 'LB=288', 'dong man she ji ', 'dongmansheji', 'dmsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (289, '视频制作', '宣传片', '1', 1, 275, 219, 'LB=275&XL=289', 'xuan chuan pian ', 'xuanchuanpian', 'xcp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (290, '视频制作', '微电影', '2', 2, 275, 219, 'LB=275&XL=290', 'wei dian ying ', 'weidianying', 'wdy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (291, '视频制作', '广告片', '3', 3, 275, 219, 'LB=275&XL=291', 'guang gao pian ', 'guanggaopian', 'ggp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (292, '视频制作', '纪录片/专题片', '4', 4, 275, 219, 'LB=275&XL=292', 'ji lu pian /zhuan ti pian ', 'jilupian/zhuantipian', 'jlp/ztp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (293, '视频制作', 'MV制作', '5', 5, 275, 219, 'LB=275&XL=293', 'MVzhi zuo ', 'MVzhizuo', 'Mz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (294, '视频制作', '栏目包装', '6', 6, 275, 219, 'LB=275&XL=294', 'lan mu bao zhuang ', 'lanmubaozhuang', 'lmbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (295, '视频制作', '影视后期制作', '7', 7, 275, 219, 'LB=275&XL=295', 'ying shi hou qi zhi zuo ', 'yingshihouqizhizuo', 'yshqzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (296, '视频制作', '光盘刻录', '8', 8, 275, 219, 'LB=275&XL=296', 'guang pan ke lu ', 'guangpankelu', 'gpkl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (297, '视频制作', '动画制作', '9', 9, 275, 219, 'LB=275&XL=297', 'dong hua zhi zuo ', 'donghuazhizuo', 'dhzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (298, '平面设计', '书籍装帧设计', '1', 1, 277, 219, 'LB=277&XL=298', 'shu ji zhuang zheng she ji ', 'shujizhuangzhengsheji', 'sjzzsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (299, '平面设计', '画册设计', '2', 2, 277, 219, 'LB=277&XL=299', 'hua ce she ji ', 'huacesheji', 'hcsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (300, '平面设计', '海报设计', '3', 3, 277, 219, 'LB=277&XL=300', 'hai bao she ji ', 'haibaosheji', 'hbsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (301, '平面设计', '折页设计', '4', 4, 277, 219, 'LB=277&XL=301', 'zhe ye she ji ', 'zheyesheji', 'zysj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (302, '品牌策划推广', '品牌策划', '1', 1, 279, 219, 'LB=279&XL=302', 'pin pai ce hua ', 'pinpaicehua', 'ppch');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (303, '品牌策划推广', '企业形象设计/CI设计', '2', 2, 279, 219, 'LB=279&XL=303', 'qi ye xing xiang she ji /CIshe ji ', 'qiyexingxiangsheji/CIsheji', 'qyxxsj/Cj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (304, '工业设计', '包装设计', '1', 1, 280, 219, 'LB=280&XL=304', 'bao zhuang she ji ', 'baozhuangsheji', 'bzsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (305, '工业设计', '模具设计', '2', 2, 280, 219, 'LB=280&XL=305', 'mo ju she ji ', 'mojusheji', 'mjsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (306, '工业设计', '电子产品设计', '3', 3, 280, 219, 'LB=280&XL=306', 'dian zi chan pin she ji ', 'dianzichanpinsheji', 'dzcpsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (307, '工业设计', '仪器仪表设计', '4', 4, 280, 219, 'LB=280&XL=307', 'yi qi yi biao she ji ', 'yiqiyibiaosheji', 'yqybsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (308, '工业设计', '灯具设计', '5', 5, 280, 219, 'LB=280&XL=308', 'deng ju she ji ', 'dengjusheji', 'djsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (309, '工业设计', '机械设计', '6', 6, 280, 219, 'LB=280&XL=309', 'ji xie she ji ', 'jixiesheji', 'jxsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (310, '工业设计', '电气设计', '7', 7, 280, 219, 'LB=280&XL=310', 'dian qi she ji ', 'dianqisheji', 'dqsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (311, '工业设计', '模型制作/设计', '8', 8, 280, 219, 'LB=280&XL=311', 'mo xing zhi zuo /she ji ', 'moxingzhizuo/sheji', 'mxzz/sj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (312, '广告传媒类别', '广告位招租', '1', 1, null, 220, 'LB=312', 'guang gao wei zhao zu ', 'guanggaoweizhaozu', 'ggwzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (313, '广告传媒类别', '导视系统设计', '2', 2, null, 220, 'LB=313', 'dao shi xi tong she ji ', 'daoshixitongsheji', 'dsxtsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (314, '广告传媒类别', '多媒体互动', '3', 3, null, 220, 'LB=314', 'dong mei ti hu dong ', 'dongmeitihudong', 'dmthd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (315, '广告位招租', '出租车/车体广告', '1', 1, 312, 220, 'LB=312&XL=315', 'chu zu che /che ti guang gao ', 'chuzuche/chetiguanggao', 'czc/ctgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (316, '广告位招租', '高速广告', '2', 2, 312, 220, 'LB=312&XL=316', 'gao su guang gao ', 'gaosuguanggao', 'gsgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (317, '广告位招租', '机场广告', '3', 3, 312, 220, 'LB=312&XL=317', 'ji chang guang gao ', 'jichangguanggao', 'jcgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (318, '广告位招租', '社区学校', '4', 4, 312, 220, 'LB=312&XL=318', 'she qu xue xiao ', 'shequxuexiao', 'sqxx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (319, '广告位招租', '地铁广告', '5', 5, 312, 220, 'LB=312&XL=319', 'di tie guang gao ', 'ditieguanggao', 'dtgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (320, '广告位招租', '加油站广告', '6', 6, 312, 220, 'LB=312&XL=320', 'jia you zhan guang gao ', 'jiayouzhanguanggao', 'jyzgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (321, '广告位招租', 'LED大屏广告', '7', 7, 312, 220, 'LB=312&XL=321', 'LEDda ping guang gao ', 'LEDdapingguanggao', 'Lpgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (322, '广告位招租', '车站广告', '8', 8, 312, 220, 'LB=312&XL=322', 'che zhan guang gao ', 'chezhanguanggao', 'czgg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (323, '广告位招租', '电视广播', '9', 9, 312, 220, 'LB=312&XL=323', 'dian shi guang bo ', 'dianshiguangbo', 'dsgb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (324, '广告位招租', '报纸杂志', '10', 10, 312, 220, 'LB=312&XL=324', 'bao zhi za zhi ', 'baozhizazhi', 'bzzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (325, '广告位招租', '网络新媒体', '11', 11, 312, 220, 'LB=312&XL=325', 'wang luo xin mei ti ', 'wangluoxinmeiti', 'wlxmt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (326, '展会服务类别', '展会庆典策划', '1', 1, null, 221, 'LB=326', 'zhan hui qing dian ce hua ', 'zhanhuiqingdiancehua', 'zhqdch');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (327, '展会服务类别', '展位设计', '2', 2, null, 221, 'LB=327', 'zhan wei she ji ', 'zhanweisheji', 'zwsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (328, '展会服务类别', '展会布置/搭建', '3', 3, null, 221, 'LB=328', 'zhan hui bu zhi /da jian ', 'zhanhuibuzhi/dajian', 'zhbz/dj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (329, '展会服务类别', '展会用品制作', '4', 4, null, 221, 'LB=329', 'zhan hui yong pin zhi zuo ', 'zhanhuiyongpinzhizuo', 'zhypzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (330, '展位设计', '展厅设计', '1', 1, 327, 221, 'LB=327&XL=330', 'zhan ting she ji ', 'zhantingsheji', 'ztsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (331, '展位设计', '展台设计', '2', 2, 327, 221, 'LB=327&XL=331', 'zhan tai she ji ', 'zhantaisheji', 'ztsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (332, '展位设计', '展柜设计', '3', 3, 327, 221, 'LB=327&XL=332', 'zhan gui she ji ', 'zhanguisheji', 'zgsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (333, '展会布置/搭建', '会场/展厅布置', '1', 1, 328, 221, 'LB=328&XL=333', 'hui chang /zhan ting bu zhi ', 'huichang/zhantingbuzhi', 'hc/ztbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (334, '展会布置/搭建', '舞台/展台搭建', '2', 2, 328, 221, 'LB=328&XL=334', 'wu tai /zhan tai da jian ', 'wutai/zhantaidajian', 'wt/ztdj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (335, '展会布置/搭建', '标摊搭建', '3', 3, 328, 221, 'LB=328&XL=335', 'biao tan da jian ', 'biaotandajian', 'btdj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (336, '展会用品制作', '展柜制作', '1', 1, 329, 221, 'LB=329&XL=336', 'zhan gui zhi zuo ', 'zhanguizhizuo', 'zgzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (337, '展会用品制作', '展板制作', '2', 2, 329, 221, 'LB=329&XL=337', 'zhan ban zhi zuo ', 'zhanbanzhizuo', 'zbzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (338, '展会用品制作', '气球拱门', '3', 3, 329, 221, 'LB=329&XL=338', 'qi qiu gong men ', 'qiqiugongmen', 'qqgm');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (339, '展会用品制作', '礼炮烟花', '4', 4, 329, 221, 'LB=329&XL=339', 'li pao yan hua ', 'lipaoyanhua', 'lpyh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (340, '展会服务类别', '摄影摄像', '5', 5, null, 221, 'LB=340', 'she ying she xiang ', 'sheyingshexiang', 'sysx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (341, '制卡类别', '智能卡/电子标签', '1', 1, null, 223, 'LB=341', 'zhi neng ka /dian zi biao qian ', 'zhinengka/dianzibiaoqian', 'znk/dzbq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (342, '制卡类别', 'PVC卡', '2', 2, null, 223, 'LB=342', 'PVCka ', 'PVCka', 'P');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (343, '制卡类别', '纸卡', '3', 3, null, 223, 'LB=343', 'zhi ka ', 'zhika', 'zk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (344, '制卡类别', '金属卡', '4', 4, null, 223, 'LB=344', 'jin shu ka ', 'jinshuka', 'jsk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (345, '制卡类别', '磁条卡', '5', 5, null, 223, 'LB=345', 'ci tiao ka ', 'citiaoka', 'ctk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (346, '制卡类别', '滴胶卡', '6', 6, null, 223, 'LB=346', 'di jiao ka ', 'dijiaoka', 'djk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (347, '智能卡/电子标签', 'IC卡', '1', 1, 341, 223, 'LB=341&XL=347', 'ICka ', 'ICka', 'I');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (348, '智能卡/电子标签', 'ID卡', '2', 2, 341, 223, 'LB=341&XL=348', 'IDka ', 'IDka', 'I');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (349, '智能卡/电子标签', 'M1卡', '3', 3, 341, 223, 'LB=341&XL=349', 'M1ka ', 'M1ka', 'M');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (350, '智能卡/电子标签', '可视卡', '4', 4, 341, 223, 'LB=341&XL=350', 'ke shi ka ', 'keshika', 'ksk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (351, '智能卡/电子标签', '电子标签/射频卡', '5', 5, 341, 223, 'LB=341&XL=351', 'dian zi biao qian /she pin ka ', 'dianzibiaoqian/shepinka', 'dzbq/spk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (352, '卡型', '人像卡', '1', 1, null, 223, 'XL', 'ren xiang ka ', 'renxiangka', 'rxk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (353, '卡型', '会员卡', '2', 2, null, 223, 'XL', 'hui yuan ka ', 'huiyuanka', 'hyk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (354, '卡型', '异形卡', '3', 3, null, 223, 'XL', 'yi xing ka ', 'yixingka', 'yxk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (355, '卡型', '年历卡', '4', 4, null, 223, 'XL', 'nian li ka ', 'nianlika', 'nlk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (356, '卡型', '贵宾卡/VIP卡', '5', 5, null, 223, 'XL', 'gui bin ka /VIPka ', 'guibinka/VIPka', 'gbk/V');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (357, '卡型', '刮刮卡', '6', 6, null, 223, 'XL', 'gua gua ka ', 'guaguaka', 'ggk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (358, '卡型', '积分卡', '7', 7, null, 223, 'XL', 'ji fen ka ', 'jifenka', 'jfk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (359, '卡型', '优惠卡', '8', 8, null, 223, 'XL', 'you hui ka ', 'youhuika', 'yhk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (360, '卡型', '条码卡', '9', 9, null, 223, 'XL', 'tiao ma ka ', 'tiaomaka', 'tmk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (361, '卡型', '充值卡', '10', 10, null, 223, 'XL', 'chong zhi ka ', 'chongzhika', 'czk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (362, '卡型', '礼品卡', '11', 11, null, 223, 'XL', 'li pin ka ', 'lipinka', 'lpk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (363, '卡型', '磨砂卡', '12', 12, null, 223, 'XL', 'mo sha ka ', 'moshaka', 'msk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (364, '礼品定制类别', '数码电子', '1', 1, null, 223, 'LB=364', 'shu ma dian zi ', 'shumadianzi', 'smdz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (365, '礼品定制类别', '杯子茶具', '2', 2, null, 223, 'LB=365', 'bei zi cha ju ', 'beizichaju', 'bzcj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (366, '礼品定制类别', '文具本册', '3', 3, null, 223, 'LB=366', 'wen ju ben ce ', 'wenjubence', 'wjbc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (367, '礼品定制类别', '箱包皮具', '4', 4, null, 223, 'LB=367', 'xiang bao pi ju ', 'xiangbaopiju', 'xbpj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (368, '礼品定制类别', '服装', '5', 5, null, 223, 'LB=368', 'fu zhuang ', 'fuzhuang', 'fz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (370, '礼品定制类别', '家居家纺', '6', 6, null, 223, 'LB=370', 'jia ju jia fang ', 'jiajujiafang', 'jjjf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (371, '礼品定制类别', '汽车/户外', '7', 7, null, 223, 'LB=371', 'qi che /hu wai ', 'qiche/huwai', 'qc/hw');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (372, '礼品定制类别', '运动健康', '8', 8, null, 223, 'LB=372', 'yun dong jian kang ', 'yundongjiankang', 'ydjk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (373, '礼品定制类别', '小家电', '9', 9, null, 223, 'LB=373', 'xiao jia dian ', 'xiaojiadian', 'xjd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (374, '礼品定制类别', '工艺品', '10', 10, null, 223, 'LB=374', 'gong yi pin ', 'gongyipin', 'gyp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (375, '礼品定制类别', '奖杯证书', '11', 11, null, 223, 'LB=375', 'jiang bei zheng shu ', 'jiangbeizhengshu', 'jbzs');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (376, '网络布线/维护类别', '安防监控', '1', 1, null, 227, 'LB=376', 'an fang jian kong ', 'anfangjiankong', 'afjk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (377, '网络布线/维护类别', '综合布线', '2', 2, null, 227, 'LB=377', 'zong he bu xian ', 'zonghebuxian', 'zhbx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (378, '网络布线/维护类别', '系统集成', '3', 3, null, 227, 'LB=378', 'xi tong ji cheng ', 'xitongjicheng', 'xtjc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (379, '网络布线/维护类别', '网络维护', '4', 4, null, 227, 'LB=379', 'wang luo wei hu ', 'wangluoweihu', 'wlwh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (380, '网络布线/维护类别', 'IT外包', '5', 5, null, 227, 'LB=380', 'ITwai bao ', 'ITwaibao', 'Ib');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (381, '网络布线/维护类别', '电脑组装', '6', 6, null, 227, 'LB=381', 'dian nao zu zhuang ', 'diannaozuzhuang', 'dnzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (382, '网络布线/维护类别', '光纤宽带', '7', 7, null, 227, 'LB=382', 'guang xian kuan dai ', 'guangxiankuandai', 'gxkd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (383, '网络布线/维护类别', '弱电工程', '8', 8, null, 227, 'LB=383', 'ruo dian gong cheng ', 'ruodiangongcheng', 'rdgc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (384, '安防监控', '监控系统', '1', 1, 376, 227, 'LB=376&XL=384', 'jian kong xi tong ', 'jiankongxitong', 'jkxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (385, '安防监控', '防盗报警', '2', 2, 376, 227, 'LB=376&XL=385', 'fang dao bao jing ', 'fangdaobaojing', 'fdbj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (386, '安防监控', '消防系统', '3', 3, 376, 227, 'LB=376&XL=386', 'xiao fang xi tong ', 'xiaofangxitong', 'xfxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (387, '安防监控', '门禁考勤', '4', 4, 376, 227, 'LB=376&XL=387', 'men jin kao qin ', 'menjinkaoqin', 'mjkq');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (388, '安防监控', '出入口控制', '5', 5, 376, 227, 'LB=376&XL=388', 'chu ru kou kong zhi ', 'churukoukongzhi', 'crkkz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (389, '安防监控', '巡更系统', '6', 6, 376, 227, 'LB=376&XL=389', 'xun geng xi tong ', 'xungengxitong', 'xgxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (390, '弱电工程', '停车场管理系统', '1', 1, 383, 227, 'LB=383&XL=390', 'ting che chang guan li xi tong ', 'tingchechangguanlixitong', 'tccglxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (391, '弱电工程', '机房建设', '2', 2, 383, 227, 'LB=383&XL=391', 'ji fang jian she ', 'jifangjianshe', 'jfjs');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (392, '弱电工程', '公共广播', '3', 3, 383, 227, 'LB=383&XL=392', 'gong gong guang bo ', 'gonggongguangbo', 'gggb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (393, '弱电工程', '对讲系统', '4', 4, 383, 227, 'LB=383&XL=393', 'dong jiang xi tong ', 'dongjiangxitong', 'djxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (394, '弱电工程', 'LED显示屏/触摸屏', '5', 5, 383, 227, 'LB=383&XL=394', 'LEDxian shi ping /chu mo ping ', 'LEDxianshiping/chumoping', 'Lsp/cmp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (395, '弱电工程', '集团电话', '6', 6, 383, 227, 'LB=383&XL=395', 'ji tuan dian hua ', 'jituandianhua', 'jtdh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (396, '弱电工程', '视频音频会议系统', '7', 7, 383, 227, 'LB=383&XL=396', 'shi pin yin pin hui yi xi tong ', 'shipinyinpinhuiyixitong', 'spyphyxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (397, '弱电工程', '背景音乐', '8', 8, 383, 227, 'LB=383&XL=397', 'bei jing yin le ', 'beijingyinle', 'bjyl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (398, '弱电工程', '楼宇自控', '9', 9, 383, 227, 'LB=383&XL=398', 'lou yu zi kong ', 'louyuzikong', 'lyzk');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (399, '弱电工程', '检票系统', '10', 10, 383, 227, 'LB=383&XL=399', 'jian piao xi tong ', 'jianpiaoxitong', 'jpxt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (400, '弱电工程', '智能家居', '11', 11, 383, 227, 'LB=383&XL=400', 'zhi neng jia ju ', 'zhinengjiaju', 'znjj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (401, '弱电工程', '多媒体教学', '12', 12, 383, 227, 'LB=383&XL=401', 'dong mei ti jiao xue ', 'dongmeitijiaoxue', 'dmtjx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (402, '网站建设/推广类别', '网站建设/设计', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (403, '网站建设/推广类别', '软件开发', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (404, '网站建设/推广类别', 'app开发', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (405, '网站建设/推广类别', '域名注册', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (406, '网站建设/推广类别', '网络营销/推广', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (407, '网站建设/推广类别', '服务器', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (408, '网站建设/推广类别', '企业邮箱', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (409, '网站建设/推广类别', '网站维护', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (410, '网站建设/设计', '网站建设', '1', 1, 402, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (411, '网站建设/设计', '网站设计', '2', 2, 402, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (412, '软件开发', '系统软件', '1', 1, 403, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (413, '软件开发', '应用软件', '2', 2, 403, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (414, '软件开发', '数据库', '3', 3, 403, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (415, '软件开发', '游戏', '4', 4, 403, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (416, 'app开发', 'ios', '1', 1, 404, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (417, 'app开发', 'android', '2', 2, 404, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (418, 'app开发', 'Windows PHONE', '3', 3, 404, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (419, 'app开发', 'html5', '4', 4, 404, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (420, 'app开发', '微信开发', '5', 5, 404, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (421, '网络营销/推广', 'SEO/SEM', '1', 1, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (422, '网络营销/推广', '视频营销', '2', 2, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (423, '网络营销/推广', '微博营销', '3', 3, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (424, '网络营销/推广', '短信营销', '4', 4, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (425, '网络营销/推广', '电话营销', '5', 5, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (426, '网络营销/推广', '邮箱营销', '6', 6, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (427, '网络营销/推广', '微信营销', '7', 7, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (428, '网络营销/推广', '事件炒作', '8', 8, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (429, '网络营销/推广', '论坛/社区推广', '9', 9, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (430, '网络营销/推广', '软文推广', '10', 10, 406, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (431, '服务器', '云主机', '1', 1, 407, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (432, '服务器', '虚拟主机', '2', 2, 407, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (433, '服务器', 'vps主机', '3', 3, 407, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (434, '服务器', '服务器租用', '4', 4, 407, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (435, '服务器', '主机托管', '5', 5, 407, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (436, '咨询服务类别', '人才/职介', '1', 1, null, 235, 'LB=436', 'ren cai /zhi jie ', 'rencai/zhijie', 'rc/zj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (437, '咨询服务类别', '户口咨询', '2', 2, null, 235, 'LB=437', 'hu kou zi xun ', 'hukouzixun', 'hkzx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (438, '咨询服务类别', '心理咨询', '3', 3, null, 235, 'LB=438', 'xin li zi xun ', 'xinlizixun', 'xlzx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (439, '咨询服务类别', '企业公关', '4', 4, null, 235, 'LB=439', 'qi ye gong guan ', 'qiyegongguan', 'qygg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (440, '咨询服务类别', '市场调查', '5', 5, null, 235, 'LB=440', 'shi chang diao cha ', 'shichangdiaocha', 'scdc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (441, '咨询服务类别', '代缴社保/公积金', '6', 6, null, 235, 'LB=441', 'dai jiao she bao /gong ji jin ', 'daijiaoshebao/gongjijin', 'djsb/gjj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (442, '快递类别', '同城快递', '1', 1, null, 214, 'LB=442', 'tong cheng kuai di ', 'tongchengkuaidi', 'tckd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (443, '快递类别', '国内快递', '2', 2, null, 214, 'LB=443', 'guo nei kuai di ', 'guoneikuaidi', 'gnkd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (444, '快递类别', '国际快递', '3', 3, null, 214, 'LB=444', 'guo ji kuai di ', 'guojikuaidi', 'gjkd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (445, '国内快递', 'ems', '1', 1, 443, 214, 'LB=443&XL=445', 'ems', 'ems', 'e');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (446, '国内快递', '顺丰', '2', 2, 443, 214, 'LB=443&XL=446', 'shun feng ', 'shunfeng', 'sf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (447, '国内快递', '申通', '3', 3, 443, 214, 'LB=443&XL=447', 'shen tong ', 'shentong', 'st');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (448, '国内快递', '圆通', '4', 4, 443, 214, 'LB=443&XL=448', 'yuan tong ', 'yuantong', 'yt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (449, '国内快递', '韵达', '5', 5, 443, 214, 'LB=443&XL=449', 'yun da ', 'yunda', 'yd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (450, '国内快递', '中通', '6', 6, 443, 214, 'LB=443&XL=450', 'zhong tong ', 'zhongtong', 'zt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (451, '国内快递', '天天', '7', 7, 443, 214, 'LB=443&XL=451', 'tian tian ', 'tiantian', 'tt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (452, '国内快递', '汇通', '8', 8, 443, 214, 'LB=443&XL=452', 'hui tong ', 'huitong', 'ht');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (453, '国内快递', '联邦', '9', 9, 443, 214, 'LB=443&XL=453', 'lian bang ', 'lianbang', 'lb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (454, '国内快递', 'ups', '10', 10, 443, 214, 'LB=443&XL=454', 'ups', 'ups', 'u');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (455, '国内快递', '速尔', '11', 11, 443, 214, 'LB=443&XL=455', 'su dong ', 'sudong', 'sd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (456, '国内快递', '国通', '12', 12, 443, 214, 'LB=443&XL=456', 'guo tong ', 'guotong', 'gt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (457, '国内快递', '快捷', '13', 13, 443, 214, 'LB=443&XL=457', 'kuai jie ', 'kuaijie', 'kj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (458, '国内快递', '优速', '14', 14, 443, 214, 'LB=443&XL=458', 'you su ', 'yousu', 'ys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (459, '国内快递', '全峰', '15', 15, 443, 214, 'LB=443&XL=459', 'quan feng ', 'quanfeng', 'qf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (460, '国内快递', '宅急送', '16', 16, 443, 214, 'LB=443&XL=460', 'zhai ji song ', 'zhaijisong', 'zjs');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (461, '国内快递', '百世汇通', '17', 17, 443, 214, 'LB=443&XL=461', 'bai shi hui tong ', 'baishihuitong', 'bsht');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (462, '国内快递', '其他', '18', 18, 443, 214, 'LB=443&XL=462', 'qi ta ', 'qita', 'qt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (463, '国际快递', 'ems', '1', 1, 444, 214, 'LB=444&XL=463', 'ems', 'ems', 'e');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (464, '国际快递', '联邦', '2', 2, 444, 214, 'LB=444&XL=464', 'lian bang ', 'lianbang', 'lb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (465, '国际快递', 'ups', '3', 3, 444, 214, 'LB=444&XL=465', 'ups', 'ups', 'u');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (466, '国际快递', 'dhl', '4', 4, 444, 214, 'LB=444&XL=466', 'dhl', 'dhl', 'd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (467, '国际快递', 'tnt', '5', 5, 444, 214, 'LB=444&XL=467', 'tnt', 'tnt', 't');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (468, '国际快递', '马士基', '6', 6, 444, 214, 'LB=444&XL=468', 'ma shi ji ', 'mashiji', 'msj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (469, '翻译/速记类别', '笔译', '1', 1, null, 234, 'LB=469', 'bi yi ', 'biyi', 'by');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (470, '翻译/速记类别', '口译', '2', 2, null, 234, 'LB=470', 'kou yi ', 'kouyi', 'ky');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (471, '翻译/速记类别', '同声传译', '3', 3, null, 234, 'LB=471', 'tong sheng chuan yi ', 'tongshengchuanyi', 'tscy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (472, '翻译/速记类别', '本地化', '4', 4, null, 234, 'LB=472', 'ben di hua ', 'bendihua', 'bdh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (473, '翻译/速记类别', '速记', '5', 5, null, 234, 'LB=473', 'su ji ', 'suji', 'sj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (474, '口译', '商务谈判', '1', 1, 470, 234, 'LB=470&XL=474', 'shang wu tan pan ', 'shangwutanpan', 'swtp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (475, '口译', '交替传译', '2', 2, 470, 234, 'LB=470&XL=475', 'jiao ti chuan yi ', 'jiaotichuanyi', 'jtcy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (476, '口译', '小型会议', '3', 3, 470, 234, 'LB=470&XL=476', 'xiao xing hui yi ', 'xiaoxinghuiyi', 'xxhy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (477, '口译', '中型会议', '4', 4, 470, 234, 'LB=470&XL=477', 'zhong xing hui yi ', 'zhongxinghuiyi', 'zxhy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (478, '口译', '大型会议', '5', 5, 470, 234, 'LB=470&XL=478', 'da xing hui yi ', 'daxinghuiyi', 'dxhy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (479, '口译', '商务考察', '6', 6, 470, 234, 'LB=470&XL=479', 'shang wu kao cha ', 'shangwukaocha', 'swkc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (480, '口译', '驻外翻译', '7', 7, 470, 234, 'LB=470&XL=480', 'zhu wai fan yi ', 'zhuwaifanyi', 'zwfy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (481, '口译', '短期出国', '8', 8, 470, 234, 'LB=470&XL=481', 'dong qi chu guo ', 'dongqichuguo', 'dqcg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (482, '口译', '外事活动', '9', 9, 470, 234, 'LB=470&XL=482', 'wai shi huo dong ', 'waishihuodong', 'wshd');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (483, '口译', '长期外派', '10', 10, 470, 234, 'LB=470&XL=483', 'chang qi wai pai ', 'changqiwaipai', 'cqwp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (484, '口译', '展览陪同', '11', 11, 470, 234, 'LB=470&XL=484', 'zhan lan pei tong ', 'zhanlanpeitong', 'zlpt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (485, '口译', '旅游陪同', '12', 12, 470, 234, 'LB=470&XL=485', 'lv you pei tong ', 'lvyoupeitong', 'lypt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (486, '口译', '新闻发布', '13', 13, 470, 234, 'LB=470&XL=486', 'xin wen fa bu ', 'xinwenfabu', 'xwfb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (487, '本地化', '网站本地化', '1', 1, 472, 234, 'LB=472&XL=487', 'wang zhan ben di hua ', 'wangzhanbendihua', 'wzbdh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (488, '本地化', '影音本地化', '2', 2, 472, 234, 'LB=472&XL=488', 'ying yin ben di hua ', 'yingyinbendihua', 'yybdh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (489, '本地化', '软件本地化', '3', 3, 472, 234, 'LB=472&XL=489', 'ruan jian ben di hua ', 'ruanjianbendihua', 'rjbdh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (490, '本地化', '游戏本地化', '4', 4, 472, 234, 'LB=472&XL=490', 'you xi ben di hua ', 'youxibendihua', 'yxbdh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (491, '本地化', '课件本地化', '5', 5, 472, 234, 'LB=472&XL=491', 'ke jian ben di hua ', 'kejianbendihua', 'kjbdh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (492, '本地化', 'DTP排版', '6', 6, 472, 234, 'LB=472&XL=492', 'DTPpai ban ', 'DTPpaiban', 'Db');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (493, '速记', '会议现场记录', '1', 1, 473, 234, 'LB=473&XL=493', 'hui yi xian chang ji lu ', 'huiyixianchangjilu', 'hyxcjl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (494, '速记', '网络文字直播', '2', 2, 473, 234, 'LB=473&XL=494', 'wang luo wen zi zhi bo ', 'wangluowenzizhibo', 'wlwzzb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (495, '速记', '录音整理', '3', 3, 473, 234, 'LB=473&XL=495', 'lu yin zheng li ', 'luyinzhengli', 'lyzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (496, '速记', '口述整理', '4', 4, 473, 234, 'LB=473&XL=496', 'kou shu zheng li ', 'koushuzhengli', 'kszl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (497, '速记', '音频视频速记', '5', 5, 473, 234, 'LB=473&XL=497', 'yin pin shi pin su ji ', 'yinpinshipinsuji', 'ypspsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (498, '速记', '电视字幕制作', '6', 6, 473, 234, 'LB=473&XL=498', 'dian shi zi mu zhi zuo ', 'dianshizimuzhizuo', 'dszmzz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (499, '速记', '采访现场速记', '7', 7, 473, 234, 'LB=473&XL=499', 'cai fang xian chang su ji ', 'caifangxianchangsuji', 'cfxcsj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (500, '速记', '大量文字录入', '8', 8, 473, 234, 'LB=473&XL=500', 'da liang wen zi lu ru ', 'daliangwenziluru', 'dlwzlr');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (501, '语种', '阿塞拜疆语', 'A', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (502, '语种', '阿布哈兹语', 'A', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (503, '语种', '阿尔瓦语', 'A', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (504, '语种', '阿拉伯语', 'A', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (505, '语种', '阿尔巴尼亚语', 'A', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (506, '语种', '阿非利堪斯语', 'A', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (507, '语种', '布里亚特语', 'B', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (508, '语种', '巴什基尔语', 'B', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (509, '语种', '白俄罗斯', 'B', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (510, '语种', '巴利语', 'B', 10, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (511, '语种', '波斯语', 'B', 11, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (512, '语种', '巴斯克语', 'B', 12, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (513, '语种', '冰岛语', 'B', 13, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (514, '语种', '波兰语', 'B', 14, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (515, '语种', '德语', 'D', 15, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (516, '语种', '达尔金语', 'D', 16, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (517, '语种', '东干语', 'D', 17, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (518, '语种', '丹麦语', 'D', 18, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (519, '语种', '俄语', 'E', 19, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (520, '语种', '法语', 'F', 20, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (521, '语种', '梵文', 'F', 21, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (522, '语种', '芬兰语', 'F', 22, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (523, '语种', '菲律宾语', 'F', 23, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (524, '语种', '方言', 'F', 24, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (525, '语种', '格鲁吉亚语', 'G', 25, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (526, '语种', '韩语', 'H', 26, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (527, '语种', '哈萨克语', 'H', 27, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (528, '语种', '豪萨语', 'H', 28, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (529, '语种', '荷兰语', 'H', 29, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (530, '语种', '汉语', 'H', 30, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (531, '语种', '吉尔吉斯语', 'J', 31, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (532, '语种', '捷克语', 'J', 32, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (533, '语种', '库梅克语', 'K', 33, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (534, '语种', '卡巴尔达语', 'K', 34, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (535, '语种', '科米语', 'K', 35, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (536, '语种', '克罗地亚语', 'K', 36, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (537, '语种', '拉脱维亚语', 'L', 37, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (538, '语种', '列兹金语', 'L', 38, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (539, '语种', '立陶宛语', 'L', 39, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (540, '语种', '拉克语', 'L', 40, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (541, '语种', '罗马尼亚语', 'L', 41, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (542, '语种', '老挝语', 'L', 42, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (543, '语种', '拉丁语', 'L', 43, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (544, '语种', '马里语', 'M', 44, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (545, '语种', '缅甸语', 'M', 45, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (546, '语种', '孟加拉语', 'M', 46, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (547, '语种', '蒙古语', 'M', 47, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (548, '语种', '马来语', 'M', 48, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (549, '语种', '挪威语', 'N', 49, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (550, '语种', '葡萄牙语', 'P', 50, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (551, '语种', '日语', 'R', 51, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (552, '语种', '瑞典语', 'R', 52, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (553, '语种', '塞尔维亚语', 'S', 53, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (554, '语种', '斯瓦西里语', 'S', 54, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (555, '语种', '斯洛文尼亚语', 'S', 55, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (556, '语种', '泰国语', 'T', 56, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (557, '语种', '土耳其语', 'T', 57, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (558, '语种', '乌尔都语', 'W', 58, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (559, '语种', '乌克兰语', 'W', 59, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (560, '语种', '希伯来语', 'X', 60, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (561, '语种', '希腊语', 'X', 61, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (562, '语种', '匈牙利语', 'X', 62, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (563, '语种', '西班牙语', 'X', 63, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (564, '语种', '英语', 'Y', 64, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (565, '语种', '印古什语', 'Y', 65, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (566, '语种', '亚美尼亚语', 'Y', 66, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (567, '语种', '印地语', 'Y', 67, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (568, '语种', '越南语', 'Y', 68, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (569, '语种', '意大利语', 'Y', 69, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (570, '语种', '印度尼西亚语', 'Y', 70, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (571, '专业领域', '医学', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (572, '专业领域', '法律', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (573, '专业领域', '机械', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (574, '专业领域', '外贸', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (575, '专业领域', 'IT', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (576, '专业领域', '金融', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (577, '专业领域', '工程', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (578, '专业领域', '环境', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (579, '专业领域', '文学', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (580, '专业领域', '建筑', '10', 10, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (581, '专业领域', '航空', '11', 11, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (582, '专业领域', '化工', '12', 12, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (583, '专业领域', '汽车', '13', 13, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (584, '专业领域', '科技', '14', 14, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (585, '专业领域', '石油', '15', 15, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (586, '专业领域', '地质', '16', 16, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (587, '专业领域', '农业', '17', 17, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (588, '专业领域', '造纸印刷', '18', 18, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (589, '专业领域', '电力', '19', 19, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (590, '专业领域', '物流', '20', 20, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (591, '专业领域', '证劵', '21', 21, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (592, '专业领域', '社科', '22', 22, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (593, '专业领域', '能源', '23', 23, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (594, '专业领域', '教育', '24', 24, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (595, '专业领域', '食品', '25', 25, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (596, '专业领域', '生物', '26', 26, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (597, '文件类型', '论文', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (598, '文件类型', '简历', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (599, '文件类型', '证件', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (600, '文件类型', '图书文献', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (601, '文件类型', '合同协议', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (602, '文件类型', '专利', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (603, '文件类型', '标书', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (604, '文件类型', '手册/说明书', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (605, '文件类型', '图纸翻译', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (606, '文件类型', '出国/留学材料', '10', 10, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (607, '文件类型', '文凭', '11', 11, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (608, '文件类型', '职业资格证', '12', 12, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (609, '文件类型', '房产证件', '13', 13, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (610, '文件类型', '工商财税证', '14', 14, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (611, '文件类型', '车牌档案', '15', 15, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (612, '文件类型', '等级证书', '16', 16, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (613, '文件类型', '司法文书', '17', 17, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (614, '文件类型', '新闻', '18', 18, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (615, '文件类型', '审计', '19', 19, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (616, '文件类型', '广告', '20', 20, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (617, '货运物流类别', '仓储', '1', 1, null, 215, 'LB=617', 'cang chu ', 'cangchu', 'cc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (618, '货运物流类别', '托运', '2', 2, null, 215, 'LB=618', 'tuo yun ', 'tuoyun', 'ty');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (619, '货运物流类别', '空车配货', '3', 3, null, 215, 'LB=619', 'kong che pei huo ', 'kongchepeihuo', 'kcph');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (620, '货运物流类别', '航空运输', '4', 4, null, 215, 'LB=620', 'hang kong yun shu ', 'hangkongyunshu', 'hkys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (621, '货运物流类别', '全国零担', '5', 5, null, 215, 'LB=621', 'quan guo ling dan ', 'quanguolingdan', 'qgld');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (622, '货运物流类别', '进出口报关', '6', 6, null, 215, 'LB=622', 'jin chu kou bao guan ', 'jinchukoubaoguan', 'jckbg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (623, '货运物流类别', '货运代理', '7', 7, null, 215, 'LB=623', 'huo yun dai li ', 'huoyundaili', 'hydl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (624, '组货方式', '零整不限', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (625, '组货方式', '整车', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (626, '组货方式', '整舱', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (627, '组货方式', '集装箱', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (628, '组货方式', '拼货', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (629, '组货方式', '零担', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (630, '组货方式', '包裹', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (631, '货物种类', '普通货物', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (632, '货物种类', '大件货物', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (633, '货物种类', '鲜活易腐', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (634, '货物种类', '危险货物', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (635, '货物种类', '贵重货物', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (636, '货物种类', '保湿冷藏', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (637, '货物种类', '搬家货物', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (638, '服务延伸', '上门提货', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (639, '服务延伸', '送货上门', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (640, '运输价格单位', '元/吨', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (641, '运输价格单位', '元/车', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (642, '运输价格单位', '元/方', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (643, '办公设备维修类别', '投影仪', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (644, '办公设备维修类别', '绘图仪', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (645, '办公设备维修类别', '喷码机', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (646, '办公设备维修类别', '印刷机', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (647, '办公设备维修类别', '打印机', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (648, '办公设备维修类别', '复印机', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (649, '办公设备维修类别', '传真机', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (650, '办公设备维修类别', '扫描仪', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (651, '办公设备维修类别', '考勤机', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (652, '办公设备维修类别', '一体机', '10', 10, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (653, '办公设备维修类别', 'LED显示屏/触摸屏', '11', 11, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (654, '办公设备维修类别', '碎纸机', '12', 12, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (655, '办公设备维修类别', '监控/门禁', '13', 13, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (656, '办公设备维修类别', '安防系统', '14', 14, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (657, '办公设备维修类别', '集团电话', '15', 15, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (658, '办公设备维修类别', '视频/音频会议系统', '16', 16, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (659, '办公设备维修类别', '广播系统', '17', 17, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (660, '打印机', '惠普', '1', 1, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (661, '打印机', '佳能', '2', 2, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (662, '打印机', '爱普生', '3', 3, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (663, '打印机', '三星', '4', 4, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (664, '打印机', '联想', '5', 5, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (665, '打印机', '兄弟', '6', 6, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (666, '打印机', '松下', '7', 7, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (667, '打印机', '富士施乐', '8', 8, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (668, '打印机', '京瓷', '9', 9, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (669, '打印机', '柯尼卡美能达', '10', 10, 647, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (670, '复印机', '东芝', '1', 1, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (671, '复印机', '理光', '2', 2, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (672, '复印机', '夏普', '3', 3, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (673, '复印机', '佳能', '4', 4, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (674, '复印机', '美能达', '5', 5, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (675, '复印机', '施乐', '6', 6, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (676, '复印机', '京瓷', '7', 7, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (677, '复印机', '松下', '8', 8, 648, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (678, '传真机', '三洋', '1', 1, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (679, '传真机', '松下', '2', 2, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (680, '传真机', '三星', '3', 3, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (681, '传真机', '惠普', '4', 4, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (682, '传真机', '佳能', '5', 5, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (683, '传真机', '夏普', '6', 6, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (684, '传真机', '兄弟', '7', 7, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (685, '传真机', '飞利浦', '8', 8, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (686, '传真机', '傲发', '9', 9, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (687, '传真机', '理光', '10', 10, 649, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (688, '一体机', '松下', '1', 1, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (689, '一体机', '兄弟', '2', 2, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (690, '一体机', '联想', '3', 3, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (691, '一体机', '三星', '4', 4, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (692, '一体机', '爱普生', '5', 5, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (693, '一体机', '佳能', '6', 6, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (694, '一体机', '惠普', '7', 7, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (695, '一体机', '东芝', '8', 8, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (696, '一体机', '理光', '9', 9, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (697, '一体机', '柯尼卡美能达', '10', 10, 652, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (698, '租赁类别', '机械设备租赁', '1', 1, null, 228, 'LB=698', 'ji xie she bei zu lin ', 'jixieshebeizulin', 'jxsbzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (699, '租赁类别', '办公设备租赁', '2', 2, null, 228, 'LB=699', 'ban gong she bei zu lin ', 'bangongshebeizulin', 'bgsbzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (700, '租赁类别', '庆典会展租赁', '3', 3, null, 228, 'LB=700', 'qing dian hui zhan zu lin ', 'qingdianhuizhanzulin', 'qdhzzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (701, '租赁类别', '服装租赁', '4', 4, null, 228, 'LB=701', 'fu zhuang zu lin ', 'fuzhuangzulin', 'fzzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (702, '租赁类别', '家具租赁', '5', 5, null, 228, 'LB=702', 'jia ju zu lin ', 'jiajuzulin', 'jjzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (703, '租赁类别', '空调租赁', '6', 6, null, 228, 'LB=703', 'kong diao zu lin ', 'kongdiaozulin', 'kdzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (704, '租赁类别', '户外装备租赁', '7', 7, null, 228, 'LB=704', 'hu wai zhuang bei zu lin ', 'huwaizhuangbeizulin', 'hwzbzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (705, '租赁类别', '移动厕所租赁', '8', 8, null, 228, 'LB=705', 'yi dong ce suo zu lin ', 'yidongcesuozulin', 'ydcszl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (706, '机械设备租赁', '发电机租赁', '1', 1, 698, 228, 'LB=698&XL=706', 'fa dian ji zu lin ', 'fadianjizulin', 'fdjzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (707, '机械设备租赁', '建材设备租赁', '2', 2, 698, 228, 'LB=698&XL=707', 'jian cai she bei zu lin ', 'jiancaishebeizulin', 'jcsbzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (708, '机械设备租赁', '动力设备租赁', '3', 3, 698, 228, 'LB=698&XL=708', 'dong li she bei zu lin ', 'donglishebeizulin', 'dlsbzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (709, '机械设备租赁', '起重吊装租赁', '4', 4, 698, 228, 'LB=698&XL=709', 'qi zhong diao zhuang zu lin ', 'qizhongdiaozhuangzulin', 'qzdzzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (710, '机械设备租赁', '混泥土机械租赁', '5', 5, 698, 228, 'LB=698&XL=710', 'hun ni tu ji xie zu lin ', 'hunnitujixiezulin', 'hntjxzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (711, '机械设备租赁', '土石方机械租赁', '6', 6, 698, 228, 'LB=698&XL=711', 'tu shi fang ji xie zu lin ', 'tushifangjixiezulin', 'tsfjxzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (712, '机械设备租赁', '桩工桥梁机械租赁', '7', 7, 698, 228, 'LB=698&XL=712', 'zhuang gong qiao liang ji xie zu lin ', 'zhuanggongqiaoliangjixiezulin', 'zgqljxzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (713, '机械设备租赁', '路面机械租赁', '8', 8, 698, 228, 'LB=698&XL=713', 'lu mian ji xie zu lin ', 'lumianjixiezulin', 'lmjxzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (714, '办公设备租赁', '电脑租赁', '1', 1, 699, 228, 'LB=699&XL=714', 'dian nao zu lin ', 'diannaozulin', 'dnzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (715, '办公设备租赁', '复印机租赁', '2', 2, 699, 228, 'LB=699&XL=715', 'fu yin ji zu lin ', 'fuyinjizulin', 'fyjzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (716, '办公设备租赁', '打印机租赁', '3', 3, 699, 228, 'LB=699&XL=716', 'da yin ji zu lin ', 'dayinjizulin', 'dyjzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (717, '办公设备租赁', '传真机租赁', '4', 4, 699, 228, 'LB=699&XL=717', 'chuan zhen ji zu lin ', 'chuanzhenjizulin', 'czjzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (718, '办公设备租赁', '投影仪租赁', '5', 5, 699, 228, 'LB=699&XL=718', 'tou ying yi zu lin ', 'touyingyizulin', 'tyyzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (719, '办公设备租赁', '显示器租赁', '6', 6, 699, 228, 'LB=699&XL=719', 'xian shi qi zu lin ', 'xianshiqizulin', 'xsqzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (720, '庆典会展租赁', '气球拱门', '1', 1, 700, 228, 'LB=700&XL=720', 'qi qiu gong men ', 'qiqiugongmen', 'qqgm');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (721, '庆典会展租赁', '场地租赁', '2', 2, 700, 228, 'LB=700&XL=721', 'chang di zu lin ', 'changdizulin', 'cdzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (722, '庆典会展租赁', '舞台设备', '3', 3, 700, 228, 'LB=700&XL=722', 'wu tai she bei ', 'wutaishebei', 'wtsb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (723, '庆典会展租赁', '同传设备', '4', 4, 700, 228, 'LB=700&XL=723', 'tong chuan she bei ', 'tongchuanshebei', 'tcsb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (724, '庆典会展租赁', '对讲机', '5', 5, 700, 228, 'LB=700&XL=724', 'dong jiang ji ', 'dongjiangji', 'djj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (725, '庆典会展租赁', '摄像机', '6', 6, 700, 228, 'LB=700&XL=725', 'she xiang ji ', 'shexiangji', 'sxj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (726, '庆典会展租赁', 'LED大屏', '7', 7, 700, 228, 'LB=700&XL=726', 'LEDda ping ', 'LEDdaping', 'Lp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (727, '庆典会展租赁', 'AV设备', '8', 8, 700, 228, 'LB=700&XL=727', 'AVshe bei ', 'AVshebei', 'Ab');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (728, '庆典会展租赁', '表决投票设备', '9', 9, 700, 228, 'LB=700&XL=728', 'biao jue tou piao she bei ', 'biaojuetoupiaoshebei', 'bjtpsb');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (729, '庆典会展租赁', '庆典用品', '10', 10, 700, 228, 'LB=700&XL=729', 'qing dian yong pin ', 'qingdianyongpin', 'qdyp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (730, '服装租赁', '礼服租赁', '1', 1, 701, 228, 'LB=701&XL=730', 'li fu zu lin ', 'lifuzulin', 'lfzl');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (731, '服装租赁', '舞蹈服装', '2', 2, 701, 228, 'LB=701&XL=731', 'wu dao fu zhuang ', 'wudaofuzhuang', 'wdfz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (732, '服装租赁', '合唱服装', '3', 3, 701, 228, 'LB=701&XL=732', 'he chang fu zhuang ', 'hechangfuzhuang', 'hcfz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (733, '服装租赁', '礼仪服装', '4', 4, 701, 228, 'LB=701&XL=733', 'li yi fu zhuang ', 'liyifuzhuang', 'lyfz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (734, '服装租赁', '戏曲服装', '5', 5, 701, 228, 'LB=701&XL=734', 'xi qu fu zhuang ', 'xiqufuzhuang', 'xqfz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (735, '服装租赁', '民族服装', '6', 6, 701, 228, 'LB=701&XL=735', 'min zu fu zhuang ', 'minzufuzhuang', 'mzfz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (736, '服装租赁', '古代服装', '7', 7, 701, 228, 'LB=701&XL=736', 'gu dai fu zhuang ', 'gudaifuzhuang', 'gdfz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (737, '服装租赁', '卡通服装', '8', 8, 701, 228, 'LB=701&XL=737', 'ka tong fu zhuang ', 'katongfuzhuang', 'ktfz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (738, '家具租赁', '办公桌椅', '1', 1, 702, 228, 'LB=702&XL=738', 'ban gong zhuo yi ', 'bangongzhuoyi', 'bgzy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (739, '家具租赁', '床/床铺', '2', 2, 702, 228, 'LB=702&XL=739', 'chuang /chuang pu ', 'chuang/chuangpu', 'c/cp');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (740, '家具租赁', '演讲台', '3', 3, 702, 228, 'LB=702&XL=740', 'yan jiang tai ', 'yanjiangtai', 'yjt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (741, '家具租赁', '沙发', '4', 4, 702, 228, 'LB=702&XL=741', 'sha fa ', 'shafa', 'sf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (742, '家具租赁', '屏风', '5', 5, 702, 228, 'LB=702&XL=742', 'ping feng ', 'pingfeng', 'pf');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (743, '建筑维修类别', '打井', '1', 1, null, 230, 'LB=743', 'da jing ', 'dajing', 'dj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (744, '建筑维修类别', '高空防腐', '2', 2, null, 230, 'LB=744', 'gao kong fang fu ', 'gaokongfangfu', 'gkff');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (745, '建筑维修类别', '专业破碎', '3', 3, null, 230, 'LB=745', 'zhuan ye po sui ', 'zhuanyeposui', 'zyps');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (746, '建筑维修类别', '抗震加固', '4', 4, null, 230, 'LB=746', 'kang zhen jia gu ', 'kangzhenjiagu', 'kzjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (747, '建筑维修类别', '基础灌浆', '5', 5, null, 230, 'LB=747', 'ji chu guan jiang ', 'jichuguanjiang', 'jcgj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (748, '建筑维修类别', '化学锚栓', '6', 6, null, 230, 'LB=748', 'hua xue mao shuan ', 'huaxuemaoshuan', 'hxms');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (749, '建筑维修类别', '植筋加固', '7', 7, null, 230, 'LB=749', 'zhi jin jia gu ', 'zhijinjiagu', 'zjjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (750, '建筑维修类别', '桥梁加固', '8', 8, null, 230, 'LB=750', 'qiao liang jia gu ', 'qiaoliangjiagu', 'qljg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (751, '建筑维修类别', '专业拆除', '9', 9, null, 230, 'LB=751', 'zhuan ye chai chu ', 'zhuanyechaichu', 'zycc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (752, '建筑维修类别', '碳纤维加固', '10', 10, null, 230, 'LB=752', 'tan xian wei jia gu ', 'tanxianweijiagu', 'txwjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (753, '建筑维修类别', '别墅改造加固', '11', 11, null, 230, 'LB=753', 'bie shu gai zao jia gu ', 'bieshugaizaojiagu', 'bsgzjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (754, '建筑维修类别', '粘钢加固', '12', 12, null, 230, 'LB=754', 'zhan gang jia gu ', 'zhangangjiagu', 'zgjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (755, '建筑维修类别', '包钢加固', '13', 13, null, 230, 'LB=755', 'bao gang jia gu ', 'baogangjiagu', 'bgjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (756, '建筑维修类别', '窗口加固', '14', 14, null, 230, 'LB=756', 'chuang kou jia gu ', 'chuangkoujiagu', 'ckjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (757, '建筑维修类别', '开门洞加固', '15', 15, null, 230, 'LB=757', 'kai men dong jia gu ', 'kaimendongjiagu', 'kmdjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (758, '建筑维修类别', '混凝土切割加固', '16', 16, null, 230, 'LB=758', 'hun ning tu qie ge jia gu ', 'hunningtuqiegejiagu', 'hntqgjg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (759, '机械设备维修类别', '医疗设备维修', '1', 1, null, 231, 'LB=759', 'yi liao she bei wei xiu ', 'yiliaoshebeiweixiu', 'ylsbwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (760, '机械设备维修类别', '美容健身设备维修', '2', 2, null, 231, 'LB=760', 'mei rong jian shen she bei wei xiu ', 'meirongjianshenshebeiweixiu', 'mrjssbwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (761, '机械设备维修类别', '工业机械设备维修', '3', 3, null, 231, 'LB=761', 'gong ye ji xie she bei wei xiu ', 'gongyejixieshebeiweixiu', 'gyjxsbwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (762, '机械设备维修类别', '农用机械设备维修', '4', 4, null, 231, 'LB=762', 'nong yong ji xie she bei wei xiu ', 'nongyongjixieshebeiweixiu', 'nyjxsbwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (763, '机械设备维修类别', '变频机械设备维修', '5', 5, null, 231, 'LB=763', 'bian pin ji xie she bei wei xiu ', 'bianpinjixieshebeiweixiu', 'bpjxsbwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (764, '机械设备维修类别', '工程机械设备维修', '6', 6, null, 231, 'LB=764', 'gong cheng ji xie she bei wei xiu ', 'gongchengjixieshebeiweixiu', 'gcjxsbwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (765, '机械设备维修类别', '水泥设备维修', '7', 7, null, 231, 'LB=765', 'shui ni she bei wei xiu ', 'shuinishebeiweixiu', 'snsbwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (766, '机械设备维修类别', '电动工具维修', '8', 8, null, 231, 'LB=766', 'dian dong gong ju wei xiu ', 'diandonggongjuweixiu', 'ddgjwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (767, '机械设备维修类别', '仪表仪器维修', '9', 9, null, 231, 'LB=767', 'yi biao yi qi wei xiu ', 'yibiaoyiqiweixiu', 'ybyqwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (768, '机械设备维修类别', '光学仪器维修', '10', 10, null, 231, 'LB=768', 'guang xue yi qi wei xiu ', 'guangxueyiqiweixiu', 'gxyqwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (769, '机械设备维修类别', '物理仪器维修', '11', 11, null, 231, 'LB=769', 'wu li yi qi wei xiu ', 'wuliyiqiweixiu', 'wlyqwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (770, '机械设备维修类别', '电子天平维修', '12', 12, null, 231, 'LB=770', 'dian zi tian ping wei xiu ', 'dianzitianpingweixiu', 'dztpwx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (771, '代办签证/签注类别', '港澳通行证/签注', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (772, '代办签证/签注类别', '入台证/台湾通行证', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (773, '代办签证/签注类别', '护照', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (774, '代办签证/签注类别', '旅游签证', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (775, '代办签证/签注类别', '商务签证', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (776, '代办签证/签注类别', '工作签证', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (777, '代办签证/签注类别', '探亲访友签证', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (778, '代办签证/签注类别', '留学签证', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (779, '代办签证/签注类别', '移民签证', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (780, '国家', '奥地利', 'A', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (781, '国家', '阿根廷', 'A', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (782, '国家', '埃塞俄比亚', 'A', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (783, '国家', '阿联酋', 'A', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (784, '国家', '埃及', 'A', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (785, '国家', '澳大利亚', 'A', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (786, '国家', '比利时', 'B', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (787, '国家', '冰岛', 'B', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (788, '国家', '巴西', 'B', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (789, '国家', '不丹', 'B', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (790, '国家', '朝鲜', 'C', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (791, '国家', '德国', 'D', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (792, '国家', '丹麦', 'D', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (793, '国家', '俄罗斯', 'E', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (794, '国家', '法国', 'F', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (795, '国家', '芬兰', 'F', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (796, '国家', '菲律宾', 'F', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (797, '国家', '斐济', 'F', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (798, '国家', '哥伦比亚', 'G', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (799, '国家', '荷兰', 'H', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (800, '国家', '韩国', 'H', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (801, '国家', '捷克共和国', 'J', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (802, '国家', '加拿大', 'J', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (803, '国家', '柬埔寨', 'J', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (804, '国家', '喀麦隆', 'K', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (805, '国家', '肯尼亚', 'K', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (806, '国家', '卢森堡', 'L', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (807, '国家', '老挝', 'L', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (808, '国家', '摩纳哥', 'M', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (809, '国家', '美国', 'M', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (810, '国家', '秘鲁', 'M', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (811, '国家', '毛里求斯', 'M', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (812, '国家', '马来西亚', 'M', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (813, '国家', '马尔代夫', 'M', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (814, '国家', '挪威', 'N', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (815, '国家', '尼日利亚', 'N', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (816, '国家', '尼泊尔', 'N', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (817, '国家', '葡萄牙', 'P', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (818, '国家', '瑞士', 'R', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (819, '国家', '瑞典', 'R', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (820, '国家', '日本', 'R', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (821, '国家', '斯洛伐克', 'S', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (822, '国家', '沙特阿拉伯', 'S', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (823, '国家', '塞舌尔', 'S', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (824, '国家', '斯里兰卡', 'S', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (825, '国家', '土耳其', 'T', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (826, '国家', '泰国', 'T', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (827, '国家', '乌克兰', 'W', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (828, '国家', '委内瑞拉', 'W', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (829, '国家', '希腊', 'X', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (830, '国家', '西班牙', 'X', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (831, '国家', '匈牙利', 'X', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (832, '国家', '新加坡', 'X', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (833, '国家', '新西兰', 'X', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (834, '国家', '意大利', 'Y', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (835, '国家', '英国', 'Y', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (836, '国家', '伊朗', 'Y', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (837, '国家', '约旦', 'Y', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (838, '国家', '伊拉克', 'Y', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (839, '国家', '以色列', 'Y', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (840, '国家', '印度尼西亚', 'Y', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (841, '国家', '越南', 'Y', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (842, '国家', '印度', 'Y', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (843, '国家', '智利', 'Z', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (844, '摄影摄像类别', '写真/艺术照', '1', 1, null, 225, 'LB=844', 'xie zhen /yi shu zhao ', 'xiezhen/yishuzhao', 'xz/ysz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (845, '摄影摄像类别', '儿童摄影', '2', 2, null, 225, 'LB=845', 'dong tong she ying ', 'dongtongsheying', 'dtsy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (846, '摄影摄像类别', '商业摄影', '3', 3, null, 225, 'LB=846', 'shang ye she ying ', 'shangyesheying', 'sysy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (847, '摄影摄像类别', '摄像录像', '4', 4, null, 225, 'LB=847', 'she xiang lu xiang ', 'shexiangluxiang', 'sxlx');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (848, '摄影摄像类别', '彩扩冲印', '5', 5, null, 225, 'LB=848', 'cai kuo chong yin ', 'caikuochongyin', 'ckcy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (849, '摄影摄像类别', '相框相册制作', '6', 6, null, 225, 'LB=849', 'xiang kuang xiang ce zhi zuo ', 'xiangkuangxiangcezhizuo', 'xkxczz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (850, '摄影摄像类别', '证件照', '7', 7, null, 225, 'LB=850', 'zheng jian zhao ', 'zhengjianzhao', 'zjz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (851, '拍摄风格', '韩式', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (852, '拍摄风格', '欧式', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (853, '拍摄风格', '中式', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (854, '拍摄风格', '古典', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (855, '拍摄风格', '浪漫', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (856, '拍摄风格', '清纯', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (857, '拍摄风格', '性感', '7', 7, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (858, '拍摄风格', '另类', '8', 8, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (859, '拍摄风格', '怀旧', '9', 9, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (860, '年龄段', '1岁以下', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (861, '年龄段', '1岁到3岁', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (862, '年龄段', '3岁到8岁', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (863, '年龄段', '8岁到12岁', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (864, '年龄段', '12岁以上', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (865, '礼仪庆典类别', '庆典公司', '1', 1, null, 226, 'LB=865', 'qing dian gong si ', 'qingdiangongsi', 'qdgs');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (866, '礼仪庆典类别', '演出表演', '2', 2, null, 226, 'LB=866', 'yan chu biao yan ', 'yanchubiaoyan', 'ycby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (867, '礼仪庆典类别', '场地布置', '3', 3, null, 226, 'LB=867', 'chang di bu zhi ', 'changdibuzhi', 'cdbz');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (868, '礼仪庆典类别', '展览展会', '4', 4, null, 226, 'LB=868', 'zhan lan zhan hui ', 'zhanlanzhanhui', 'zlzh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (869, '礼仪庆典类别', '活动策划', '5', 5, null, 226, 'LB=869', 'huo dong ce hua ', 'huodongcehua', 'hdch');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (870, '礼仪庆典类别', '礼仪模特', '6', 6, null, 226, 'LB=870', 'li yi mo te ', 'liyimote', 'lymt');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (871, '演出表演', '魔术表演', '1', 1, 866, 226, 'LB=866&XL=871', 'mo shu biao yan ', 'moshubiaoyan', 'msby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (872, '演出表演', '舞龙醒狮', '2', 2, 866, 226, 'LB=866&XL=872', 'wu long xing shi ', 'wulongxingshi', 'wlxs');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (873, '演出表演', '民俗杂技', '3', 3, 866, 226, 'LB=866&XL=873', 'min su za ji ', 'minsuzaji', 'mszj');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (874, '演出表演', '沙画表演', '4', 4, 866, 226, 'LB=866&XL=874', 'sha hua biao yan ', 'shahuabiaoyan', 'shby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (875, '演出表演', '武术/跆拳道表演', '5', 5, 866, 226, 'LB=866&XL=875', 'wu shu /tai quan dao biao yan ', 'wushu/taiquandaobiaoyan', 'ws/tqdby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (876, '演出表演', '茶艺表演', '6', 6, 866, 226, 'LB=866&XL=876', 'cha yi biao yan ', 'chayibiaoyan', 'cyby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (877, '演出表演', '舞蹈表演', '7', 7, 866, 226, 'LB=866&XL=877', 'wu dao biao yan ', 'wudaobiaoyan', 'wdby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (878, '演出表演', '歌手/乐队演出', '8', 8, 866, 226, 'LB=866&XL=878', 'ge shou /le dong yan chu ', 'geshou/ledongyanchu', 'gs/ldyc');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (879, '演出表演', '器乐表演', '9', 9, 866, 226, 'LB=866&XL=879', 'qi le biao yan ', 'qilebiaoyan', 'qlby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (880, '演出表演', '曲艺表演', '10', 10, 866, 226, 'LB=866&XL=880', 'qu yi biao yan ', 'quyibiaoyan', 'qyby');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (881, '演出表演', '威风锣鼓', '11', 11, 866, 226, 'LB=866&XL=881', 'wei feng luo gu ', 'weifengluogu', 'wflg');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (882, '演出表演', '人体彩绘/活体雕塑', '12', 12, 866, 226, 'LB=866&XL=882', 'ren ti cai hui /huo ti diao su ', 'renticaihui/huotidiaosu', 'rtch/htds');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (883, '活动策划', '发布会', '1', 1, 869, 226, 'LB=869&XL=883', 'fa bu hui ', 'fabuhui', 'fbh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (884, '活动策划', '奠基仪式', '2', 2, 869, 226, 'LB=869&XL=884', 'dian ji yi shi ', 'dianjiyishi', 'djys');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (885, '活动策划', '企业年会', '3', 3, 869, 226, 'LB=869&XL=885', 'qi ye nian hui ', 'qiyenianhui', 'qynh');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (886, '活动策划', '生日寿宴', '4', 4, 869, 226, 'LB=869&XL=886', 'sheng ri shou yan ', 'shengrishouyan', 'srsy');

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (887, '是否上门', '上门服务', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (888, '是否上门', '到店服务', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (889, '运送范围', '国内货运专线', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (890, '运送范围', '国际货运专线', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (891, '货运通道', '公路', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (892, '货运通道', '铁路', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (893, '货运通道', '航空', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (894, '货运通道', '河运', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (895, '货运通道', '海运', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (896, '起名/风水/算命类别', '起名', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (897, '起名/风水/算命类别', '风水', '2', 2, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (898, '起名/风水/算命类别', '算命', '3', 3, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (899, '起名/风水/算命类别', '星座', '4', 4, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (900, '起名/风水/算命类别', '择吉日', '5', 5, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (901, '起名/风水/算命类别', '解梦', '6', 6, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (902, '起名', '宝宝起名', '1', 1, 896, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (903, '起名', '公司/店铺起名', '2', 2, 896, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (904, '起名', '品牌/项目起名', '3', 3, 896, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (905, '风水', '家居风水', '1', 1, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (906, '风水', '办公室风水', '2', 2, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (907, '风水', '楼盘风水', '3', 3, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (908, '风水', '公司选址', '4', 4, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (909, '风水', '店铺风水', '5', 5, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (910, '风水', '厂区风水', '6', 6, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (911, '风水', '风水吉祥物', '7', 7, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (912, '风水', '墓地风水', '8', 8, 897, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (7791, '个人/团体', '个人', '1', 1, null, null, null, null, null, null);

insert into codes_swfw (CODEID, TYPENAME, CODENAME, CODEVALUE, CODEORDER, PARENTID, LBID, CONDITION, CODENAMEPY, CODENAMEPYQKG, CODENAMEPYSZM)
values (7792, '个人/团体', '团体', '2', 2, null, null, null, null, null, null);

prompt Done.
