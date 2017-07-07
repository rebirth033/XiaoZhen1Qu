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
  is '���ݳ��������Ϣ';
-- Add comments to the columns 
comment on column FWCZJBXX.fwczid
  is '���ݳ���ID';
comment on column FWCZJBXX.jcxxid
  is '������ϢID';
comment on column FWCZJBXX.czfs
  is '���ⷽʽ';
comment on column FWCZJBXX.xqmc
  is 'С������';
comment on column FWCZJBXX.s
  is '��';
comment on column FWCZJBXX.t
  is '��';
comment on column FWCZJBXX.w
  is '��';
comment on column FWCZJBXX.pfm
  is 'ƽ����';
comment on column FWCZJBXX.cx
  is '����';
comment on column FWCZJBXX.zxqk
  is 'װ�����';
comment on column FWCZJBXX.zzlx
  is 'סլ����';
comment on column FWCZJBXX.c
  is '��';
comment on column FWCZJBXX.gjc
  is '������';
comment on column FWCZJBXX.zj
  is '���';
comment on column FWCZJBXX.yffs
  is 'Ѻ����ʽ';
comment on column FWCZJBXX.zjybhfy
  is '����Ѱ�������';
comment on column FWCZJBXX.fwpz
  is '��������';
comment on column FWCZJBXX.fwld
  is '��������';
comment on column FWCZJBXX.czyq
  is '����Ҫ��';
comment on column FWCZJBXX.fyms
  is '��Դ����';
comment on column FWCZJBXX.krzsj
  is '����סʱ��';
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
