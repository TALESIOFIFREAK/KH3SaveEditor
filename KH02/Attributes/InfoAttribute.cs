﻿/*
    Kingdom Hearts 0.2 and 3 Save Editor
    Copyright (C) 2019  Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Linq;

namespace KHSave.Attributes
{
	public class InfoAttribute : Attribute
	{
		public string Info { get; set; }

		public InfoAttribute()
		{ }

		public InfoAttribute(string info)
		{
			Info = info;
		}

		public static string GetInfo(object value)
		{
			var memberValue = value.ToString();
			var memberInfo = value.GetType().GetMember(memberValue).FirstOrDefault();

			if (memberInfo != null)
			{
				if (memberInfo.GetCustomAttributes(typeof(InfoAttribute), false)
					    .FirstOrDefault() is InfoAttribute attribute && !string.IsNullOrEmpty(attribute.Info))
				{
					return attribute.Info;
				}
			}

			return memberValue;
		}

		public static string[] GetItemTypes(object value)
		{
			var memberValue = value.ToString();
			var memberInfo = value.GetType().GetMember(memberValue).FirstOrDefault();

			if (memberInfo != null)
			{
				return memberInfo.CustomAttributes.Select(x =>
				{
					var name = x.AttributeType.Name;
					var indexAttributeStr = name.IndexOf("Attribute");
					return indexAttributeStr > 0 ? name.Substring(0, indexAttributeStr) : null;
				}).Where(x => !string.IsNullOrEmpty(x)).ToArray();
			}

			return new string[0];
		}
	}
}
