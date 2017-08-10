-- Create table
create table SZMX
(
  szmxid   VARCHAR2(50) not null,
  cjsj     DATE,
  lx       VARCHAR2(20),
  jysm     VARCHAR2(100),
  je       NUMBER(10,2),
  jelx     VARCHAR2(1),
  yhzhxxid VARCHAR2(50)
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
comment on table SZMX
  is '�û��˻�_��֧��ϸ';
-- Add comments to the columns 
comment on column SZMX.szmxid
  is '����';
comment on column SZMX.cjsj
  is '����ʱ��';
comment on column SZMX.lx
  is '����';
comment on column SZMX.jysm
  is '����˵��';
comment on column SZMX.je
  is '���';
comment on column SZMX.jelx
  is '�������';
comment on column SZMX.yhzhxxid
  is '�û��˻�ID';
-- Create/Recreate primary, unique and foreign key constraints 
alter table SZMX
  add primary key (SZMXID)
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
