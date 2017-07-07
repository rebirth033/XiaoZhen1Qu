-- Create table
create table FWCZJBXX
(
  fwczid  VARCHAR2(50) not null,
  jcxxid  VARCHAR2(50),
  czfs    NUMBER(1),
  xqmc    VARCHAR2(100),
  s       NUMBER(8),
  t       NUMBER(8),
  w       NUMBER(8),
  pfm     NUMBER(8),
  cx      VARCHAR2(20),
  zxqk    VARCHAR2(20),
  zzlx    VARCHAR2(20),
  c       NUMBER(8),
  gjc     NUMBER(8),
  zj      NUMBER(8),
  yffs    VARCHAR2(20),
  zjybhfy VARCHAR2(200),
  fwpz    VARCHAR2(200),
  fwld    VARCHAR2(200),
  czyq    VARCHAR2(200),
  fyms    VARCHAR2(4000),
  krzsj   DATE
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table FWCZJBXX
  is '房屋出租基本信息';
-- Add comments to the columns 
comment on column FWCZJBXX.fwczid
  is '房屋出租ID';
comment on column FWCZJBXX.jcxxid
  is '基础信息ID';
comment on column FWCZJBXX.czfs
  is '出租方式';
comment on column FWCZJBXX.xqmc
  is '小区名称';
comment on column FWCZJBXX.s
  is '室';
comment on column FWCZJBXX.t
  is '厅';
comment on column FWCZJBXX.w
  is '卫';
comment on column FWCZJBXX.pfm
  is '平方米';
comment on column FWCZJBXX.cx
  is '朝向';
comment on column FWCZJBXX.zxqk
  is '装修情况';
comment on column FWCZJBXX.zzlx
  is '住宅类型';
comment on column FWCZJBXX.c
  is '层';
comment on column FWCZJBXX.gjc
  is '共几层';
comment on column FWCZJBXX.zj
  is '租金';
comment on column FWCZJBXX.yffs
  is '押付方式';
comment on column FWCZJBXX.zjybhfy
  is '租金已包含费用';
comment on column FWCZJBXX.fwpz
  is '房屋配置';
comment on column FWCZJBXX.fwld
  is '房屋亮点';
comment on column FWCZJBXX.czyq
  is '出租要求';
comment on column FWCZJBXX.fyms
  is '房源描述';
comment on column FWCZJBXX.krzsj
  is '可入住时间';
-- Create/Recreate primary, unique and foreign key constraints 
alter table FWCZJBXX
  add primary key (FWCZID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
