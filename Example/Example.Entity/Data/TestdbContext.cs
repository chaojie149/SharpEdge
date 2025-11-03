using System;
using Microsoft.EntityFrameworkCore;


namespace Example.Entity.Data;

public partial class TestdbContext : DbContext
{
    public TestdbContext(DbContextOptions<TestdbContext> options)
        : base(options)
    {
    }

    #region Generated Properties
    public virtual DbSet<Example.Entity.Data.Entities.GoAdArea> GoAdAreas { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoAdData> GoAdData { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoAdmin> GoAdmins { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoAdminUsergroup> GoAdminUsergroups { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoAppoint> GoAppoints { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoArticle> GoArticles { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoBrand> GoBrands { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCaches> GoCaches { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCardPwd> GoCardPwds { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCardRecharge> GoCardRecharges { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCategory> GoCategories { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCjcode> GoCjcodes { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCjlist> GoCjlists { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoConfig> GoConfigs { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCurrency> GoCurrencies { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoCzk> GoCzks { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoDis> GoDis { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoEgglotterAward> GoEgglotterAwards { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoEgglotterRule> GoEgglotterRules { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoEgglotterSpoil> GoEgglotterSpoils { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoFund> GoFunds { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoGoogle> GoGoogles { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoKefu> GoKefus { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoLanguage> GoLanguages { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoLink> GoLinks { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoLogistics> GoLogistics { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberAccount> GoMemberAccounts { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberAddmoneyRecord> GoMemberAddmoneyRecords { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberBand> GoMemberBands { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberBindCodeRecord> GoMemberBindCodeRecords { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberBindPhone> GoMemberBindPhones { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberCashout> GoMemberCashouts { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberCommission> GoMemberCommissions { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberDel> GoMemberDels { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberDizhi> GoMemberDizhis { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberGoRecord> GoMemberGoRecords { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberGroup> GoMemberGroups { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberMessage> GoMemberMessages { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberOrderaddressBrand> GoMemberOrderaddressBrands { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberRechange> GoMemberRechanges { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberRechanges> GoMemberRechanges1 { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberRecodes> GoMemberRecodes { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMember> GoMembers { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMemberZp> GoMemberZps { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMents> GoMents { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoMobileVerify> GoMobileVerifies { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoModel> GoModels { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoNavigation> GoNavigations { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoPay3> GoPay3s { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoPay> GoPays { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoPositionData> GoPositionData { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoPosition> GoPositions { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoQiandao> GoQiandaos { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoQqset> GoQqsets { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoQuanziHueifu> GoQuanziHueifus { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoQuanzi> GoQuanzis { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoQuanziTiezi> GoQuanziTiezis { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoRechargeMoney> GoRechargeMoneys { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoRecom> GoRecoms { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoRegMoney> GoRegMoneys { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoSend> GoSends { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShaidanHueifu> GoShaidanHueifus { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShaidan> GoShaidans { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShare> GoShares { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShopcodes1> GoShopcodes1s { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShopcollect> GoShopcollects { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShoplistCopy> GoShoplistCopies { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShoplistDel> GoShoplistDels { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoShoplist> GoShoplists { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoSignIn> GoSignIns { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoSlide> GoSlides { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoTemplate> GoTemplates { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoVoteActiver> GoVoteActivers { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoVoteOption> GoVoteOptions { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoVoteSubject> GoVoteSubjects { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWap> GoWaps { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWechatConfig> GoWechatConfigs { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWeixinBonus> GoWeixinBonus { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWeixinBonusType> GoWeixinBonusTypes { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWeixinKeywords> GoWeixinKeywords { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWeixinPointRecord> GoWeixinPointRecords { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWeixinPoint> GoWeixinPoints { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWeixinSign> GoWeixinSigns { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWeixinUser> GoWeixinUsers { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoWxchCfg> GoWxchCfgs { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoZpNumber> GoZpNumbers { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.GoZpZj> GoZpZjs { get; set; } = null!;

    public virtual DbSet<Example.Entity.Data.Entities.SignIn> SignIns { get; set; } = null!;

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Generated Configuration
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoAdAreaMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoAdDataMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoAdminMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoAdminUsergroupMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoAppointMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoArticleMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoBrandMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCachesMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCardPwdMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCardRechargeMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCategoryMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCjcodeMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCjlistMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoConfigMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCurrencyMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoCzkMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoDisMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoEgglotterAwardMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoEgglotterRuleMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoEgglotterSpoilMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoFundMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoGoogleMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoKefuMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoLanguageMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoLinkMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoLogisticsMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberAccountMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberAddmoneyRecordMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberBandMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberBindCodeRecordMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberBindPhoneMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberCashoutMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberCommissionMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberDelMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberDizhiMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberGoRecordMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberGroupMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberMessageMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberOrderaddressBrandMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberRechangeMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberRechangesMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberRecodesMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMemberZpMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMentsMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoMobileVerifyMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoModelMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoNavigationMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoPay3Map());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoPayMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoPositionDataMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoPositionMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoQiandaoMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoQqsetMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoQuanziHueifuMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoQuanziMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoQuanziTieziMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoRechargeMoneyMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoRecomMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoRegMoneyMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoSendMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShaidanHueifuMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShaidanMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShareMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShopcodes1Map());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShopcollectMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShoplistCopyMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShoplistDelMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoShoplistMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoSignInMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoSlideMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoTemplateMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoVoteActiverMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoVoteOptionMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoVoteSubjectMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWapMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWechatConfigMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWeixinBonusMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWeixinBonusTypeMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWeixinKeywordsMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWeixinPointMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWeixinPointRecordMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWeixinSignMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWeixinUserMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoWxchCfgMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoZpNumberMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.GoZpZjMap());
        modelBuilder.ApplyConfiguration(new Example.Entity.Data.Mapping.SignInMap());
        #endregion
    }
}
