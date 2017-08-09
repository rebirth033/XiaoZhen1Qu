-- Create table
create table SZMX
(
  szmxid VARCHAR2(50) not null,
  cjsj   DATE,
  lx     VARCHAR2(20),
  jysm   VARCHAR2(100),
  je     NUMBER(10,2)
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
-- Add comments to the columns 
comment on column SZMX.szmxid
  is '主键';
comment on column SZMX.cjsj
  is '创建时间';
comment on column SZMX.lx
  is '类型';
comment on column SZMX.jysm
  is '交易说明';
comment on column SZMX.je
  is '金额';
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
