﻿using NUnit.Framework;

namespace Qowaiv.UnitTests
{
    public partial class EmailValdationTest
    {
        [TestCase("w@com")]
        [TestCase("w.b.f@test.com")]
        [TestCase("w.b.f@test.museum")]
        [TestCase("a.a@test.com")]
        [TestCase("ab@288.120.150.10.com")]
        [TestCase("2@bde.cc")]
        [TestCase("-@bde.cc")]
        [TestCase("a2@bde.cc")]
        [TestCase("a-b@bde.cc")]
        [TestCase("ab@b-de.cc")]
        [TestCase("a+b@bde.cc")]
        [TestCase("f.f.f@bde.cc")]
        [TestCase("ab_c@bde.cc")]
        [TestCase("_-_@bde.cc")]
        [TestCase("k.haak@12move.nl")]
        [TestCase("K.HAAK@12MOVE.NL")]
        [TestCase("email@domain.com")]
        [TestCase("email@domain")]
        [TestCase("あいうえお@domain.com")]
        [TestCase("local@あいうえお.com")]
        [TestCase("firstname.lastname@domain.com")]
        [TestCase("email@subdomain.domain.com")]
        [TestCase("firstname+lastname@domain.com")]
        [TestCase("1234567890@domain.com")]
        [TestCase("a@domain.com")]
        [TestCase("a.b.c.d@domain.com")]
        [TestCase("aap.123.noot.mies@domain.com")]
        [TestCase("1@domain.com")]
        [TestCase("email@domain-one.com")]
        [TestCase("_______@domain.com")]
        [TestCase("email@domain.topleveldomain")]
        [TestCase("email@domain.co.jp")]
        [TestCase("firstname-lastname@domain.com")]
        [TestCase("firstname-lastname@d.com")]
        [TestCase("FIRSTNAME-LASTNAME@d--n.com")]
        [TestCase("first-name-last-name@d-a-n.com")]
        [TestCase("{local{name{{with{@leftbracket.com")]
        [TestCase("}local}name}}with{@rightbracket.com")]
        [TestCase("|local||name|with|@pipe.com")]
        [TestCase("%local%%name%with%@percentage.com")]
        [TestCase("$local$$name$with$@dollar.com")]
        [TestCase("&local&&name&with&$@amp.com")]
        [TestCase("#local##name#with#@hash.com")]
        [TestCase("~local~~name~with~@tilde.com")]
        [TestCase("!local!!name!with!@exclamation.com")]
        [TestCase("?local??name?with?@question.com")]
        [TestCase("*local**name*with*@asterisk.com")]
        [TestCase("`local``name`with`@grave-accent.com")]
        [TestCase("^local^^name^with^@xor.com")]
        [TestCase("=local==name=with=@equality.com")]
        [TestCase("+local++name+with+@equality.com")]
        [TestCase("Joe Smith <email@domain.com>")]
        [TestCase("email@domain.com (joe Smith)")]
        //[TestCase(@"""Joe Smith"" email@domain.com")]
        //[TestCase(@"""Joe\\tSmith"" email@domain.com")]
        //[TestCase(@"""Joe\""Smith"" email@domain.com")]
        //[TestCase(@"Test |<gaaf <email@domain.com>")]
        [TestCase("MailTo:casesensitve@domain.com")]
        [TestCase("mailto:email@domain.com")]
        [TestCase(@"Joe Smith <mailto:""quoted""@domain.com>")]
        [TestCase("Joe Smith <mailto:email@domain.com>")]
        [TestCase("Joe Smith <mailto:email(with comment)@domain.com>")]
        [TestCase("i234567890_234567890_234567890_234567890_234567890_234567890_234@long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long.long")]

        ////// IP Based.
        [TestCase("user@[IPv6:2001:db8:1ff::a0b:dbd0]")]
        [TestCase("valid.ipv4.without-brackets@123.1.72.010")]
        [TestCase("valid.ipv4.addr@[123.1.72.10]")]
        [TestCase("valid.ipv6.addr@[IPv6:0::1]")]
        [TestCase("valid.ipv6.without-brackets@2607:f0d0:1002:51::4")]
        [TestCase("valid.ipv6.without-prefix@[2607:f0d0:1002:51::4]")]
        [TestCase("valid.ipv6.addr@[IPv6:2607:f0d0:1002:51::4]")]
        [TestCase("valid.ipv6.addr@[IPv6:fe80::230:48ff:fe33:bc33]")]
        [TestCase("valid.ipv6.addr@[IPv6:fe80:0000:0000:0000:0202:b3ff:fe1e:8329]")]
        [TestCase("valid.ipv6v4.addr@[IPv6:aaaa:aaaa:aaaa:aaaa:aaaa:aaaa:127.0.0.1]")]

        // https://github.com/jstedfast/EmailValidation
        [TestCase("伊昭傑@郵件.商務")] //  Chinese
        [TestCase("राम@मोहन.ईन्फो")] //     Hindi
        [TestCase("юзер@екзампл.ком")] // Ukranian
        [TestCase("θσερ@εχαμπλε.ψομ")] // Greek
        [TestCase("\"Abc\\@def\"@example.com")]
        [TestCase("\"Fred Bloggs\"@example.com")]
        [TestCase("\"Joe\\\\Blow\"@example.com")]
        [TestCase("\"Abc@def\"@example.com")]
        [TestCase("customer/department=shipping@example.com")]
        [TestCase("!def!xyz%abc@example.com")]

        // examples from wikipedia
        [TestCase("niceandsimple@example.com")]
        [TestCase("very.common@example.com")]
        [TestCase("a.little.lengthy.but.fine@dept.example.com")]
        [TestCase("disposable.style.email.with+symbol@example.com")]
        [TestCase("\"much.more unusual\"@example.com")]
        [TestCase("\"very.unusual.@.unusual.com\"@example.com")]
        [TestCase("\"very.(),:;<>[]\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com")]
        [TestCase("postbox@com")]
        [TestCase("admin@mailserver1")]
        [TestCase("!#$%&'*+-/=?^_`{}|~@example.org")]
        [TestCase("\"()<>[]:,;@\\\\\\\"!#$%&'*+-/=?^_`{}| ~.a\"@example.org")]
        [TestCase("\" \"@example.org")]

        //// examples from https://github.com/Sembiance/email-validator
        //[TestCase("\"\\e\\s\\c\\a\\p\\e\\d\"@sld.com")]
        //[TestCase("\"back\\slash\"@sld.com")]
        //[TestCase("\"escaped\\\"quote\"@sld.com")]
        //[TestCase("\"quoted\"@sld.com")]
        //[TestCase("\"quoted-at-sign@sld.org\"@sld.com")]
        //[TestCase("&'*+-./=?^_{}~@other-valid-characters-in-local.net")]
        //[TestCase("01234567890@numbers-in-local.net")]
        //[TestCase("a@single-character-in-local.org")]
        //[TestCase("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@letters-in-local.org")]
        //[TestCase("backticksarelegit@test.com")]
        //[TestCase("country-code-tld@sld.rw")]
        //[TestCase("country-code-tld@sld.uk")]
        //[TestCase("letters-in-sld@123.com")]
        //[TestCase("local@dash-in-sld.com")]
        //[TestCase("local@sld.newTLD")]
        //[TestCase("local@sub.domains.com")]
        //[TestCase("mixed-1234-in-{+^}-local@sld.net")]
        //[TestCase("one-character-third-level@a.example.com")]
        //[TestCase("one-letter-sld@x.org")]
        //[TestCase("punycode-numbers-in-tld@sld.xn--3e0b707e")]
        //[TestCase("single-character-in-sld@x.org")]
        //[TestCase("the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-three-characters-so-it-is-valid-blah-blah.com")]
        //[TestCase("the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-254-characters-exactly.so-it-should-be-valid.and-im-going-to-add-some-more-words-here.to-increase-the-length-blah-blah-blah-blah-bla.org")]
        //[TestCase("uncommon-tld@sld.mobi")]
        //[TestCase("uncommon-tld@sld.museum")]
        //[TestCase("uncommon-tld@sld.travel")]
        public void Valid(string email) => Assert.IsTrue(EmailAddress.IsValid(email), email);
    }
}
