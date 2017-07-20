-- Create table
create table JCXX
(
  jcxxid VARCHAR2(50) not null,
  yhid   VARCHAR2(50),
  cjsj   DATE,
  zxgxsj DATE,
  llcs   NUMBER(10),
  lxr    VARCHAR2(50),
  lxdh   VARCHAR2(20),
  lxdz   VARCHAR2(200),
  qq     VARCHAR2(20),
  bt     VARCHAR2(100),
  dh     VARCHAR2(100),
  status NUMBER(2)
)
tablespace XIAOZHEN
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
comment on table JCXX
  is '������Ϣ';
-- Add comments to the columns 
comment on column JCXX.jcxxid
  is '������ϢID';
comment on column JCXX.yhid
  is '�û�ID';
comment on column JCXX.cjsj
  is '����ʱ��';
comment on column JCXX.zxgxsj
  is '���¸���ʱ��';
comment on column JCXX.llcs
  is '�������';
comment on column JCXX.lxr
  is '��ϵ��';
comment on column JCXX.lxdh
  is '��ϵ�绰';
comment on column JCXX.lxdz
  is '��ϵ��ַ';
comment on column JCXX.qq
  is 'QQ';
comment on column JCXX.bt
  is '����';
comment on column JCXX.dh
  is '����';
comment on column JCXX.status
  is '��ǰ״̬��0:ɾ��,1:��ʾ,2:����,3:����ˣ�';
-- Create/Recreate primary, unique and foreign key constraints 
alter table JCXX
  add constraint PK_JCXX primary key (JCXXID)
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
alter table JCXX
  add constraint FK_JCXX_REFERENCE_YHJBXX foreign key (YHID)
  references YHJBXX (YHID);
