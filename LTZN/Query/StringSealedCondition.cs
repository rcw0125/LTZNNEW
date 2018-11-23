﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LTZN.Query
{
    public class StringSealedCondition : SealedCondition
    {
        public string FieldValue
        {
            get;
            set;
        }

        public override string ToSql()
        {
            string result="";
            switch (this.RalationOp)
            {
                case RelationOpType.大于:
                    result = this.FieldName + " > '" + this.FieldValue + "'";
                    break;
                case RelationOpType.大于等于:
                    result = this.FieldName + " >= '" + this.FieldValue + "'";
                    break;
                case RelationOpType.小于:
                    result = this.FieldName + "< '" + this.FieldValue + "'";
                    break;
                case RelationOpType.小于等于:
                    result = this.FieldName + " <= '" + this.FieldValue + "'";
                    break;
                case RelationOpType.等于:
                    result = this.FieldName + " = '" + this.FieldValue + "'";
                    break;
                case RelationOpType.不等于:
                    result = this.FieldName + " <> '" + this.FieldValue + "'";
                    break;
                case RelationOpType.包含:
                    result = this.FieldName + " like '%" + this.FieldValue + "%'";
                    break;
                case RelationOpType.以其开始:
                    result = this.FieldName + " like '" + this.FieldValue + "%'";
                    break;
                case RelationOpType.以其结束:
                    result = this.FieldName + " like '%" + this.FieldValue + "'";
                    break;
                case RelationOpType.是空:
                    result = this.FieldName + " IS NULL";
                    break;
                case RelationOpType.非空:
                    result = this.FieldName + " IS NOT NULL"; ;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
