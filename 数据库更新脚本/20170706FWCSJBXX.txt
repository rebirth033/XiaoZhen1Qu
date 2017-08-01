-- Create table
create table FWCSJBXX
(
  fwcsid  VARCHAR2(50) not null,
  jcxxid  VARCHAR2(50),
  czfs    VARCHAR2(50),
  sf      VARCHAR2(50),
  xqmc    VARCHAR2(200),
  s       NUMBER(8),
  t       NUMBER(8),
  w       NUMBER(8),
  pfm     NUMBER(8),
  c       NUMBER(8),
  gjc     NUMBER(8),
  zj      NUMBER(8),
  yffs    NUMBER(1),
  fl      VARCHAR2(50),
  gq      VARCHAR2(50),
  lx      VARCHAR2(50),
  sfkzcgs NUMBER(1),
  lpmc    VARCHAR2(50),
  qy      VARCHAR2(50),
  sq      VARCHAR2(50),
  dd      VARCHAR2(50),
  mj      VARCHAR2(50),
  lsjy    VARCHAR2(50),
  fclx    VARCHAR2(20),
  bt      VARCHAR2(200),
  fyms    VARCHAR2(2000),
  cx      NUMBER(1),
  zxqk    NUMBER(1)
)
tablespace XIAOZHEN
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table FWCSJBXX
  is '房屋出售基本信息';
-- Add comments to the columns 
comment on column FWCSJBXX.fwcsid
  is '房屋出售ID';
comment on column FWCSJBXX.jcxxid
  is '基础信息ID';
comment on column FWCSJBXX.czfs
  is '出租方式';
comment on column FWCSJBXX.sf
  is '身份';
comment on column FWCSJBXX.xqmc
  is '小区名称';
comment on column FWCSJBXX.s
  is '室';
comment on column FWCSJBXX.t
  is '厅';
comment on column FWCSJBXX.w
  is '卫';
comment on column FWCSJBXX.pfm
  is '平方米';
comment on column FWCSJBXX.c
  is '层';
comment on column FWCSJBXX.gjc
  is '共几层';
comment on column FWCSJBXX.zj
  is '租金';
comment on column FWCSJBXX.yffs
  is '押付方式';
comment on column FWCSJBXX.fl
  is '分类';
comment on column FWCSJBXX.gq
  is '供求';
comment on column FWCSJBXX.lx
  is '类型';
comment on column FWCSJBXX.sfkzcgs
  is '是否可注册公司';
comment on column FWCSJBXX.lpmc
  is '楼盘名称';
comment on column FWCSJBXX.qy
  is '区域';
comment on column FWCSJBXX.sq
  is '商圈';
comment on column FWCSJBXX.dd
  is '地段';
comment on column FWCSJBXX.mj
  is '面积';
comment on column FWCSJBXX.lsjy
  is '历史经营';
comment on column FWCSJBXX.fclx
  is '房产类型';
comment on column FWCSJBXX.bt
  is '标题';
comment on column FWCSJBXX.fyms
  is '房源描述';
comment on column FWCSJBXX.cx
  is '朝向';
comment on column FWCSJBXX.zxqk
  is '装修情况';
